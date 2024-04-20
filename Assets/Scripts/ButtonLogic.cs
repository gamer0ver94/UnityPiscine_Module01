using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLogic : MonoBehaviour
{
    public float force;
    public GameObject[] door = null;
    private Vector3[] doorOriginalSize;
    private Vector3 initialPostion;
    public float actionTime;
    private float originalTimer;
    private bool setTimer = false;
    public float doorSpeed;
    // Start is called before the first frame update
    void Start()
    {
        initialPostion = transform.position;
        originalTimer = actionTime;
        doorOriginalSize = new Vector3[door.Length];
        for (int i = 0; i < door.Length; i++)
        {
            doorOriginalSize[i] = door[i].transform.localScale;
        }
    }

    // Update is called once per frame
    void Update()
    {
            if (setTimer && actionTime > 0)
            {
               actionTime -= Time.deltaTime;
               for (int i = 0; i < door.Length; i++){
                    if (door[i].transform.localScale.y > 0.0001)
                    {
                        door[i].transform.localScale = new Vector3(door[i].transform.localScale.x, door[i].transform.localScale.y - doorSpeed * Time.deltaTime, door[i].transform.localScale.y);
                    }
                    else if (door[i].transform.localScale.y < 1)
                    {
                        door[i].transform.localScale = new Vector3(0, 0, 0);
                        door[i].GetComponent<BoxCollider>().enabled = false;
                    }
                    if (setTimer && actionTime <= 0)
                    {
                        for (int j = 0; j < door.Length; j++)
                        {
                            door[j].GetComponent<BoxCollider>().enabled = true;
                        }
                        setTimer = false;
                        actionTime = originalTimer;
                        transform.position = initialPostion;
                    }
                    if (!setTimer && door[i].transform.localScale.y < doorOriginalSize[i].y)
                    {
                        door[i].transform.localScale = new Vector3(doorOriginalSize[i].x, doorOriginalSize[i].y + doorSpeed * Time.deltaTime, doorOriginalSize[i].z);
                    }
                }
        }
        
    }
    void OnCollisionEnter(Collision collider)
    {
        Vector3 hit = collider.contacts[0].normal;
        float angle = Vector3.Angle(hit, Vector3.up);
        if (Mathf.Approximately(angle, 180) && collider.collider.GetComponent<Renderer>().material.color == GetComponent<Renderer>().material.color)
        {
                    transform.position = transform.position +  -Vector3.up * force;
                    setTimer = true;
        }
        else if (GetComponent<Renderer>().material.color == Color.white){
            GetComponent<Renderer>().material.color = collider.collider.GetComponent<Renderer>().material.color;
            for (int i = 0; i < door.Length; i++)
            {
                door[i].GetComponent<Renderer>().material.color = collider.collider.GetComponent<Renderer>().material.color;
            }
        }
    }
}

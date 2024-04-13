using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLogic : MonoBehaviour
{
    public float force;
    public GameObject door;
    private Vector3 doorOriginalSize;
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
        doorOriginalSize = door.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (setTimer && actionTime > 0)
        {
           actionTime -= Time.deltaTime;
            if (door.transform.localScale.y > 0.0001)
            {
                door.transform.localScale = new Vector3(door.transform.localScale.x, door.transform.localScale.y - doorSpeed * Time.deltaTime, door.transform.localScale.y);
            }
            else if (door.transform.localScale.y < 1)
            {
                door.transform.localScale = new Vector3(0, 0, 0);
                door.GetComponent<BoxCollider>().enabled = false;
            }

        }
        if (setTimer && actionTime < 0)
        {
            setTimer = false;
            actionTime = originalTimer;
            transform.position = initialPostion;
            door.GetComponent<BoxCollider>().enabled = true;
        }

        if (!setTimer && door.transform.localScale.y < doorOriginalSize.y)
        {
            door.transform.localScale = new Vector3(doorOriginalSize.x, door.transform.localScale.y + doorSpeed * Time.deltaTime, doorOriginalSize.z);
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        Vector3 hit = collision.contacts[0].normal;
        float angle = Vector3.Angle(hit, Vector3.up);
        if (Mathf.Approximately(angle, 180))
        {
            transform.position = transform.position +  -Vector3.up * force;
            setTimer = true;
        }

    }
}

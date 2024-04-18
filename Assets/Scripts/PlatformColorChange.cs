using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformColorChange : MonoBehaviour
{

    public GameObject[] platform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void OnCollisionEnter(Collision collider)
    {
        Vector3 hit = collider.contacts[0].normal;
        float angle = Vector3.Angle(hit, Vector3.up);
        if (Mathf.Approximately(angle, 180))
        {
            for (int i = 0; i < platform.Length; i++)
            {
                
                if (collider.collider.GetComponent<Renderer>().material.color == Color.red){
                    Debug.Log(collider.collider.GetComponent<Renderer>().material.color.ToString());
                }
                platform[i].GetComponent<Renderer>().material.color = collider.collider.GetComponent<Renderer>().material.color;

            }
        }
    }
}

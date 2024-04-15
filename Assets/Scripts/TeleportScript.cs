using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public GameObject objectDestination;
    private bool teleportReady = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionExit(Collision collider){
        teleportReady = true;
        
    }

    void OnCollisionEnter(Collision collider)
    {
        float destinationSize = objectDestination.GetComponent<BoxCollider>().size.y / 2 + 1;
        
        float colliderSize = collider.collider.bounds.size.y / 2;
        if (teleportReady){
            GetComponent<BoxCollider>().enabled = false;
            collider.transform.position = new Vector3(objectDestination.transform.position.x, objectDestination.transform.position.y + destinationSize + colliderSize, objectDestination.transform.position.z);
            GetComponent<BoxCollider>().enabled = true;
            teleportReady = false;
        }
        
    }
}

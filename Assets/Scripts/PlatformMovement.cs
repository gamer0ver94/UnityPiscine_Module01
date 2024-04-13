using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private Vector3 initialPosition;
    public bool verticalMove = false;
    public bool horizontalMove = false;
    public float rightDistance;
    public float leftDistance;
    public float speed;
    Rigidbody rb;
    private bool turn = false;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (horizontalMove)
        {
            if (transform.position.x < initialPosition.x + rightDistance && !turn)
            {
                rb.velocity = Vector3.right * speed;
            }
            else
            {
                turn = true;
                rb.velocity = Vector3.left * speed;
                if (transform.position.x <= initialPosition.x - leftDistance)
                {
                    turn = false;
                }
            }
        }
        else if (verticalMove)
        {
            if (transform.position.y < initialPosition.y + rightDistance && !turn)
            {
                rb.velocity = Vector3.up * speed;
            }
            else
            {
                turn = true;
                rb.velocity = Vector3.down * speed;
                if (transform.position.y <= initialPosition.y - leftDistance)
                {
                    turn = false;
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        if (horizontalMove)
        {
            Gizmos.color = Color.white;
            Vector3 newPos = -Vector3.right * leftDistance;
            Gizmos.DrawRay(initialPosition, newPos);
            Gizmos.color = Color.black;
            Vector3 newPos2 = Vector3.right * rightDistance;
            Gizmos.DrawRay(initialPosition, newPos2);
        }
        else if (verticalMove)
        {
            Gizmos.color = Color.white;
            Vector3 newPos = -Vector3.up * leftDistance;
            Gizmos.DrawRay(initialPosition, newPos);
            Gizmos.color = Color.black;
            Vector3 newPos2 = Vector3.up * rightDistance;
            Gizmos.DrawRay(initialPosition, newPos2);
        }

    }
}

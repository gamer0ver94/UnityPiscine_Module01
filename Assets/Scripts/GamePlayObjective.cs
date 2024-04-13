using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayObjective : MonoBehaviour
{
    private Material ownMaterial;
    public GameObject player;
    public Vector2 leftPoint;
    public Vector2 rightPoint;
    public bool validation = false;
    Material playerMaterial;
    private BoxCollider collider;
    private Vector2 initialPos;
    // Start is called before the first frame update
    void Start()
    {
        collider = player.GetComponent<BoxCollider>();
        playerMaterial = player.GetComponent<Renderer>().material;
        ownMaterial = GetComponent<Renderer>().material;
        initialPos = new Vector2(transform.position.x, transform.position.y);
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = collider.bounds.size.x / 2;
        if (playerMaterial.color == ownMaterial.color &&
            player.transform.position.x - x > leftPoint.x + initialPos.x &&
            player.transform.position.x + x < rightPoint.x + initialPos.x &&
            player.transform.position.y >= leftPoint.y + initialPos.y &&
            player.transform.position.y >= rightPoint.y + initialPos.y)
        {
            validation = true;
        }
        else
        {
            validation = false;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 direction = Vector3.up * 5;
        Vector3 leftSide = new Vector3(transform.position.x + leftPoint.x, transform.position.y + leftPoint.y, transform.position.z);
        Vector3 rightSide = new Vector3(transform.position.x + rightPoint.x, transform.position.y + rightPoint.y, transform.position.z);
        Gizmos.DrawRay(leftSide, direction);
        Gizmos.DrawRay(rightSide, direction);
    }
}

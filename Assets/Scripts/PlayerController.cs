using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 30;
    public float maxSpeed;
    public float jumpForce = 2;
    private Rigidbody rb;
    public bool isPlayable = false;
    private CharacterSwitcher switchSystem = null;
    private bool isGrounded = true;
    private BoxCollider boxCollider;
    private PhysicMaterial originalMaterial;
    public float lowestJump;
    public float rayDistance;
    private int level;
    private bool moveLeft = false;
    private bool moveRight = false;
    private bool isJumping = false;
    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        rb = GetComponent<Rigidbody>();
        GameObject switchSystemObj = GameObject.FindGameObjectWithTag("SwitchSystem");
        boxCollider = GetComponent<BoxCollider>();
        originalMaterial = boxCollider.material;
        boxCollider.material = null;
        if (switchSystemObj != null)
        {
            switchSystem = switchSystemObj.GetComponent<CharacterSwitcher>();
        }
    }

    private void Update()
    {
        Debug.Log(level);
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene(level);
        }
        isPlayable = switchSystem.currentPlayer == this.tag ? true : false;
        if (isPlayable)
        {
            isGrounded = IsGrounded();
            if (rb.velocity.magnitude > maxSpeed)
            {
                moveLeft = false;
                moveRight = false;
            }
            else{
                moveLeft = Input.GetKey(KeyCode.A);
                moveRight = Input.GetKey(KeyCode.D);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
        }
        if (!isGrounded)
        {
            boxCollider.material = originalMaterial;
        }
        else
        {
            boxCollider.material = null;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isPlayable)
        {
            if (moveLeft)
            {
                rb.AddForce(-Vector3.right * speed);
            }
            // Control right movement
            if (moveRight)
            {
                rb.AddForce(Vector3.right * speed);
            }
            // ControlJumpm
            if (isJumping)
            {
                rb.AddForce(Vector3.up * jumpForce);
                isJumping = false;
            }
        }
        else{
            isJumping = false;
        }
        
    }

    void OnCollisionEnter(Collision collider){
        if (collider.gameObject.tag == "Terrain"){
            SceneManager.LoadScene(level);
        }
    }

    private bool IsGrounded()
    {
        Vector3 leftSide = new Vector3(transform.position.x - boxCollider.bounds.size.x / 2, transform.position.y - boxCollider.bounds.size.y / 2 + 0.05f, transform.position.z - boxCollider.bounds.size.z / 2);
        Vector3 rightSide = new Vector3(transform.position.x + boxCollider.bounds.size.x / 2, transform.position.y - boxCollider.bounds.size.y / 2 + 0.05f, transform.position.z - boxCollider.bounds.size.z / 2);
        Vector3 leftSideDeep = new Vector3(transform.position.x - boxCollider.bounds.size.x / 2, transform.position.y - boxCollider.bounds.size.y / 2 + 0.05f, transform.position.z + boxCollider.bounds.size.z / 2);
        Vector3 rightSideDeep = new Vector3(transform.position.x + boxCollider.bounds.size.x / 2, transform.position.y - boxCollider.bounds.size.y / 2 + 0.05f, transform.position.z + boxCollider.bounds.size.z / 2);
        if (Physics.Raycast(leftSide, Vector3.down, rayDistance) || Physics.Raycast(rightSide, Vector3.down, rayDistance) || Physics.Raycast(leftSideDeep, Vector3.down, rayDistance) || Physics.Raycast(rightSideDeep, Vector3.down, rayDistance)
        )
        {
            return true;
        }
        else {
            return false;
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (boxCollider != null)
        {
            Gizmos.color = Color.red;
            Vector3 direction = Vector3.down * rayDistance;
            Vector3 leftSide = new Vector3(transform.position.x - boxCollider.bounds.size.x / 2, transform.position.y - boxCollider.bounds.size.y / 2, transform.position.z - boxCollider.bounds.size.z / 2);
            Vector3 rightSide = new Vector3(transform.position.x + boxCollider.bounds.size.x / 2, transform.position.y - boxCollider.bounds.size.y / 2, transform.position.z - boxCollider.bounds.size.z / 2);
            Vector3 leftSideDeep = new Vector3(transform.position.x - boxCollider.bounds.size.x / 2, transform.position.y - boxCollider.bounds.size.y / 2, transform.position.z + boxCollider.bounds.size.z / 2);
            Vector3 rightSideDeep = new Vector3(transform.position.x + boxCollider.bounds.size.x / 2, transform.position.y - boxCollider.bounds.size.y / 2, transform.position.z + boxCollider.bounds.size.z / 2);
            Gizmos.DrawRay(leftSide, direction);
            Gizmos.DrawRay(rightSide, direction);
            Gizmos.DrawRay(leftSideDeep, direction);
            Gizmos.DrawRay(rightSideDeep, direction);
        }
        
    }

}

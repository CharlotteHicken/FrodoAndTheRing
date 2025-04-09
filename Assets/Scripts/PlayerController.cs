using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float jumpForce = 5f; 
    Rigidbody rb; 
    bool isGrounded; 
    public GameObject ring;
    public GameObject gollum;
    public float grabDistance = 2f;
    public GameObject winScreen;

    void Start()
    {
        winScreen.SetActive(false);
        ring.SetActive(true);
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Jump();

        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0); //this line of code keeps the player from rolling around and rotating, but keeps them upright

        if (Input.GetMouseButtonDown(0) && Vector3.Distance(transform.position, ring.transform.position) < grabDistance && ring.transform.parent == null) //if the ring is in range while button is pressed and nobody has the ring, make it a child so it follows the player
        {
            ring.transform.SetParent(transform);
        }
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
  
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); //change the vector based on horizontal and vertical inputs
  
        rb.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime); //apply the vector to the player and multiply it by speed and time.deltatime
    }

    void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) //if the character is on the ground and they press space, apply a force that moves them upwards
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // if colliding with the ground, set it as grounded
        {
            isGrounded = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && ring.transform.parent != gollum.transform) //if colliding with an enemy and gollum does not have the ring, drop the ring
        {
            ring.transform.SetParent(null);
        }

        if (other.gameObject.CompareTag("Lava") && ring.transform.parent == transform)
        {
            winScreen.SetActive(true);
            ring.SetActive(false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) //if not colliding with the ground, set not grounded
        {
            isGrounded = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player
    public float jumpForce = 5f; // Force applied when jumping
    private Rigidbody rb; // Reference to the Rigidbody component
    private bool isGrounded; // Check if the player is on the ground

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to the player
    }

    void Update()
    {
        Move();
        Jump();

        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }

    void Move()
    {
        // Get input from WASD or Arrow keys
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a movement vector
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Move the player
        rb.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);
    }

    void Jump()
    {
        // Check if the player is grounded and the space key is pressed
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            // Apply a force upwards
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player is touching the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Set isGrounded to false when leaving the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}

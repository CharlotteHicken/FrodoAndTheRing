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
    public float grabDistance = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Jump();

        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

        if (Input.GetMouseButtonDown(0) && Vector3.Distance(transform.position, ring.transform.position) < grabDistance )
        {
            ring.transform.SetParent(transform);
        }
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
  
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
  
        rb.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);
    }

    void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            ring.transform.SetParent(null);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}

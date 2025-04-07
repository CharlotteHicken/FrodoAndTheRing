using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : MonoBehaviour
{

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent != null) //disables the rigidbody if it has a parent, so it doesn't roll around
        {
            rb.isKinematic = true;
            rb.detectCollisions = false;
        }
        else
        {
            rb.isKinematic = false;
            rb.detectCollisions = true;
        }
    }
}

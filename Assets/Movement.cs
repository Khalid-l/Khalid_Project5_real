using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    public float jumpForce = 1000;
    private Rigidbody rb;
    public float speed = 5f;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        transform.Translate(movement * speed * Time.deltaTime);
        // Check if the space bar is pressed.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Apply a force to the player in the upwards direction.
            rb.AddForce(Vector3.up * jumpForce);
        }
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewOmar : MonoBehaviour
{

    public float speed = 12.5f;
    public float drag = 0;
    public Rigidbody rb;
    private Vector3 rot;
    public float percentage;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rot = transform.eulerAngles;
    }

    // Update is called once per frame
    private void Update()   
    {
      
        // Rotate the player
        //X
        rot.x += 20 * Input.GetAxis("Vertical") * Time.deltaTime;
        rot.x = Mathf.Clamp(rot.x, 0, 45);
        //Y
        rot.y += 20 * Input.GetAxis("Horizontal") * Time.deltaTime;
        //Z
        rot.z += -5 * Input.GetAxis("Horizontal") * Time.deltaTime;
        rot.z = Mathf.Clamp(rot.z, -5, 5);

        transform.rotation = Quaternion.Euler(rot);
        percentage = rot.x / 45;
        float mod_drag = (percentage * -2) + 6;
        float mod_speed = percentage * (13.8f - 12.5f) + 12.5f;

        rb.drag = drag;
        Vector3 localV = transform.InverseTransformDirection(rb.velocity);
        localV.z = mod_speed;
        rb.velocity = transform.TransformDirection(localV);
    }
}

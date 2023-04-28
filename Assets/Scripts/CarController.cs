using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 20.0f;
    public float acceleration = 10.0f;

    private float currentSpeed = 0.0f;
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void Update()
    {
        // Move the car forward at a constant speed
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

        // Update the current speed based on input and acceleration
        float input = Input.GetAxis("Vertical");
        currentSpeed += input * acceleration * Time.deltaTime;

        // Clamp the speed to a maximum value
        currentSpeed = Mathf.Clamp(currentSpeed, 0.0f, speed);

        // Move the car left or right based on input
        float horizontalInput = Input.GetAxis("Horizontal") * 10.0f;
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime);
    }
}

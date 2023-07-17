using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ThirdPersonMovement : MonoBehaviour
{

    public Transform cam;
    public Rigidbody rb;
    public GroundCheck groundCheck;

    //Variables
    public float speed = 20f;
    public float jumpForce = 10f;
    

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private Vector3 movementDirection;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector3(horizontal, 0f, vertical).normalized;

        if (movementDirection.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

        if (groundCheck.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {

        if (movementDirection.magnitude >= 0.1f)
        {
            Vector3 moveDir = Quaternion.Euler(0f, cam.eulerAngles.y, 0f) * movementDirection;
            rb.AddForce(moveDir * speed, ForceMode.VelocityChange);
        }
    }
}

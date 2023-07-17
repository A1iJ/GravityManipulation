using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    private Rigidbody rb;
    public float gravityMultiplier = 2f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Apply custom gravity
        Vector3 customGravity = -transform.up * gravityMultiplier;
        rb.AddForce(customGravity, ForceMode.Acceleration);
    }
}

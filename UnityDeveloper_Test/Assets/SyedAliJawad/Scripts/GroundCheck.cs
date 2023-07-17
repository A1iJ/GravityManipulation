using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("isGrounded");
        isGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("isNotGrounded");
        isGrounded = false;
    }
}


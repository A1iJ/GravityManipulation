using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HologramController : MonoBehaviour
{
    public GameObject hologram;
    public float rotationSpeed = 720f; // Adjust this value to control the rotation speed

    private Quaternion originalRotation = Quaternion.identity;
    private Quaternion rotationZ;
    private Quaternion rotationX;
    private bool isRotating = false;

    private void Start()
    {
        rotationZ = Quaternion.Euler(0f, 0f, 90f);
        rotationX = Quaternion.Euler(90f, 0f, 0f);
        hologram.SetActive(false); // Set the initial state of the hologram to inactive
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            RotateHologram(Quaternion.Inverse(rotationZ));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            RotateHologram(rotationZ);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            RotateHologram(Quaternion.Inverse(rotationX));
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            RotateHologram(rotationX);
        }
        else
        {
            StopRotation();
        }
    }

    private void RotateHologram(Quaternion target)
    {
        if (!isRotating)
        {
            isRotating = true;
            hologram.SetActive(true); // Activate the hologram when a direction key is pressed
        }

        Quaternion targetRotation = transform.rotation * target;

        hologram.transform.rotation = Quaternion.RotateTowards(hologram.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        if (Quaternion.Angle(hologram.transform.rotation, targetRotation) <= 0.1f)
        {
            Debug.Log("HologramRotation: " + hologram.transform.rotation);
            isRotating = false;
        }
    }

    private void StopRotation()
    {
        if (isRotating)
        {
            isRotating = false;
        }

        hologram.transform.rotation = Quaternion.RotateTowards(hologram.transform.rotation, originalRotation, rotationSpeed * Time.deltaTime);

        if (Quaternion.Angle(hologram.transform.rotation, originalRotation) <= 0.1f)
        {
            hologram.SetActive(false);
        }
    }
}

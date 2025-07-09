using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour

{
    public float mouseSensitivity = 100;
    public Transform playerBody;
    float xRotation = 0;
    float yRotation = 0;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Optional: Lock the cursor to the center of the screen
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        yRotation += mouseX;

        xRotation = Mathf.Clamp(xRotation, -90, 90); // Clamp vertical rotation

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0); // Rotate the camera vertically
        playerBody.transform.rotation = Quaternion.Euler(0, yRotation, 0); // Rotate the player horizontally
    }
}

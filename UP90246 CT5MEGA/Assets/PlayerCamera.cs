using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private string mouseXInputName, mouseYInputName;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Transform FPplayer;

    private float xAxisClamp;

    //calls the action of locking the cursor when the game is running
    private void Awake()
    {
        LockCursor();
        xAxisClamp = 0.0f;
    }

    //locks the camera to where the mouse cursor moves
    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        CameraRotation();
    }

    //describes how the camera rotates using the mouse
    private void CameraRotation()
    {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;

        // locks the camera so it doesn't move too far upwards
        if (xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
        }

        // locks the camera so it doesn't move too far downwards
        else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(90.0f);
            
        }

        //rotation controlled by the mouse
        transform.Rotate(Vector3.left * mouseY);
        FPplayer.Rotate(Vector3.up * mouseX);

    }

    //sets a limit for how far the camera can move upwards and downwards
    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}

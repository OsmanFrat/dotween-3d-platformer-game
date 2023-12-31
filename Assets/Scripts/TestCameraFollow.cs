using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 3f, -6f);
    public float smoothSpeed = 0.125f;
    public float rotationSpeed = 5f;
    private float mouseX;
    private float mouseY;

    private void Start() 
    {
        HideCursor();
    }
    private void FixedUpdate()
    {

        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;

        Quaternion rotation = Quaternion.Euler(0f, mouseX, 0f);
        Vector3 desiredPosition = target.position + rotation * offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }

    private void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}

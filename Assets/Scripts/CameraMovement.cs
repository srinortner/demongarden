using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // horizontal rotation speed
    public float horizontalSpeed = 1.0f;
    // vertical rotation speed
    public float verticalSpeed = 1.0f;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;
    private Camera cam;

    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * horizontalSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;

        //yRotation += mouseX;
        //xRotation -= mouseY;
        //xRotation = Mathf.Clamp(xRotation, -90, 90);

        //cam.transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    private PlayerController _playerController;
    public float MovementSpeed =1;
    public float Gravity = 9.8f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;

    private Vector3 offset;
    private float velocity = 0;
 
    private void Start()
    {
        offset = new Vector3(0f, 4.05f, -7.5f);
        characterController = GetComponent<CharacterController>();
        _playerController = GetComponent<PlayerController>();
    }
 
    void Update()
    {
        if (_playerController.isDead == false)
        {
            // player movement - forward, backward, left, right
            float horizontal = Input.GetAxis("Horizontal") * MovementSpeed;
            float vertical = Input.GetAxis("Vertical") * MovementSpeed;
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; //we only want to move in x and z axis (y is upwards movement)

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg; // Atan2 returns angle between x and y axis so we know in which direction the player is facing
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); //smoothing function for player turns
                transform.rotation = Quaternion.Euler(0f, targetAngle, 0);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                characterController.Move(moveDir.normalized * MovementSpeed * Time.deltaTime);
                cam.rotation = transform.rotation;
                Vector3 desiredPosition = transform.position + offset;
                Vector3 smoothedPosition = Vector3.Lerp(cam.position, desiredPosition, turnSmoothTime);
                cam.position = smoothedPosition;
                cam.LookAt(this.transform);
            }
            

            // Gravity
            if (characterController.isGrounded)
            {
                velocity = 0;
            }
            else
            {
                velocity -= Gravity * Time.deltaTime;
                characterController.Move(new Vector3(0, velocity, 0));
            }
        }
    }
}

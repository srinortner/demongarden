using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public
    public float movementSpeed = 2.0f;

    //private
    private CharacterController characterController;
    private PlayerController _playerController;
    // public float Gravity = 9.8f;
    // public float turnSmoothTime = 0.1f;
    // float turnSmoothVelocity;
    // public Transform cam;

    // private Vector3 offset;
    // private float velocity = 0;
    
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float rotation;


    private void Start()
    {
        // offset = new Vector3(0f, 4.05f, -7.5f);
        characterController = GetComponent<CharacterController>();
        _playerController = GetComponent<PlayerController>();
    }
 
    void Update()
    {


        if (_playerController.isDead == false)
        {
            groundedPlayer = characterController.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            Vector3 move = transform.forward * Input.GetAxis("Vertical");
            characterController.Move(move * Time.deltaTime * movementSpeed);

            rotation = Input.GetAxis ("Horizontal") * movementSpeed;
            transform.Rotate(transform.up, rotation);

        }

        //     // player movement - forward, backward, left, right
        //     float horizontal = Input.GetAxis("Horizontal") * MovementSpeed;
        //     float vertical = Input.GetAxis("Vertical") * MovementSpeed;
        //     Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; //we only want to move in x and z axis (y is upwards movement)

        //     if (direction.magnitude >= 0.1f)
        //     {
        //         float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; // Atan2 returns angle between x and y axis so we know in which direction the player is facing
        //         float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); //smoothing function for player turns
        //         // transform.rotation = Quaternion.Euler(0f, targetAngle, 0);
        //         transform.turnSmoothTime()
        //         Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        //         characterController.Move(moveDir.normalized * MovementSpeed * Time.deltaTime);
        //         //code for manual script (CameraMovement)
        //         //cam.rotation = transform.rotation;
        //         //Vector3 desiredPosition = transform.position + offset;
        //         //Vector3 smoothedPosition = Vector3.Lerp(cam.position, desiredPosition, 0.5f);
        //         //cam.position = smoothedPosition;
        //         //cam.LookAt(this.transform);
        //     }
            

        //     // Gravity
        //     if (characterController.isGrounded)
        //     {
        //         velocity = 0;
        //     }
        //     else
        //     {
        //         velocity -= Gravity * Time.deltaTime;
        //         characterController.Move(new Vector3(0, velocity, 0));
        //     }
    }
}

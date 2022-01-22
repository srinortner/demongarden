using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public
    //public float movementSpeed = 1.0f;

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
    Vector3 moveDirection = Vector3.zero;
    Vector2 rotation = Vector2.zero;

    public float speed = 7.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 0.0f;
    public Transform playerCameraParent;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;

    private bool canMove = true;


    private void Start()
    {
        // offset = new Vector3(0f, 4.05f, -7.5f);
        characterController = GetComponent<CharacterController>();
        _playerController = GetComponent<PlayerController>();

        rotation.y = transform.eulerAngles.y;
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

            // We are grounded, so recalculate move direction based on axes
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            float curSpeedX = canMove ? speed * Input.GetAxis("Vertical") : 0;
            float curSpeedY = canMove ? speed * Input.GetAxis("Horizontal") : 0;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        } else
        { //player is dead --> stop camera movement
            canMove = false;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
            rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotation.x = Mathf.Clamp(rotation.x, -lookXLimit, lookXLimit);
            playerCameraParent.localRotation = Quaternion.Euler(rotation.x, 0, 0);
            transform.eulerAngles = new Vector2(0, rotation.y);
        }
    }
}

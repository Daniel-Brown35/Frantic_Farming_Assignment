using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed;
    public float sprintSpeed;
    public float jumpForce;
    public float playerGravity;
    public float lookSensitivity;
    private float rotationX = 0;
    public bool canMove = true;

    Vector3 moveDirection = Vector3.zero;

    CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        characterController.detectCollisions = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool sprinting = Input.GetKey(KeyCode.LeftShift);
        float currentSpeedX;
        if (canMove == true)
        {
            if (sprinting == true)
            {
                currentSpeedX = sprintSpeed * Input.GetAxis("Vertical");
            }
            else
            {
                currentSpeedX = walkSpeed * Input.GetAxis("Vertical");
            }
        }
        else
        {
            currentSpeedX = 0;
        }
        float currentSpeedY;
        if (canMove == true)
        {
            if (sprinting == true)
            {
                currentSpeedY = sprintSpeed * Input.GetAxis("Horizontal");
            }
            else
            {
                currentSpeedY = walkSpeed * Input.GetAxis("Horizontal");
            }
        }
        else
        {
            currentSpeedY = 0;
        }
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * currentSpeedX) + (right * currentSpeedY);

        if (Input.GetKeyDown(KeyCode.Space) && canMove == true && characterController.isGrounded == true)
        {
            moveDirection.y = jumpForce;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (characterController.isGrounded == false)
        {
            moveDirection.y -= playerGravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove == true)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSensitivity;
            rotationX = Mathf.Clamp(rotationX, -90, 90);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation = transform.rotation * Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSensitivity, 0);
        }
    }
}

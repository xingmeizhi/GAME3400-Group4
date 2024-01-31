using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float gravity = 9.81f;
    public float jumpHeight = 0.3f;
    public float maxJumpHeight = 1f;
    public float airControl = 1f;
    public CameraZoom cameraZoom;
    private float jumpPressDuration = 0f;
    private bool isPreparingToJump = false;

    CharacterController controller;
    Vector3 input, moveDirection;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (cameraZoom != null && !cameraZoom.IsAtStartPosition)
        {
            return;
        }
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        input = (transform.right * moveHorizontal + transform.forward * moveVertical).normalized;
        input *= moveSpeed;

        if (controller.isGrounded)
        {
            moveDirection = input;

            if (Input.GetButtonDown("Jump"))
            {
                isPreparingToJump = true;
                jumpPressDuration = 0f;
            }

            if (isPreparingToJump && Input.GetButtonUp("Jump"))
            {
                isPreparingToJump = false;
                float scaledJumpHeight = Mathf.SmoothStep(jumpHeight, maxJumpHeight, Mathf.Sqrt(jumpPressDuration));
                moveDirection.y = Mathf.Sqrt(2 * scaledJumpHeight * gravity);
            }

            if (isPreparingToJump)
            {
                jumpPressDuration += Time.deltaTime;
                jumpPressDuration = Mathf.Clamp(jumpPressDuration, 0f, 1f);
            }
        }
        else
        {
            input.y = moveDirection.y;
            moveDirection = Vector3.Lerp(moveDirection, input, airControl * Time.deltaTime);
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}

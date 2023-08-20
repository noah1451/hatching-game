using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("MOVEMENT")]
    public CharacterController controller;
    public ViewBobbing VB;
    public float MovementSpeed = 6;
    public float gravity = -9.81f;
    [Space(5)]
    [Header("GROUND SETTINGS")]
    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask groundMask;
    [Space(5)]
    [Header("JUMP SETTINGS")]
    public bool CanJump = true;
    public float JumpHeight = 1.5f;
    [Space(5)]
    [Header("SPRINT SETTINGS")]
    public float AdditiveSpeed = 4;
    public KeyCode SprintKey = KeyCode.LeftShift;
    public float AdditiveBob = 4;
    [Space(5)]
    [Header("DEBUG")]
    public Vector3 velocity;
    public bool isGrounded;
    public bool isSprinting;
    public float sprintSpeed;
    public float sprintBOB;
    public float normalBOB;

    // Start is called before the first frame update
    void Start()
    {
        sprintSpeed = MovementSpeed + AdditiveSpeed;
        sprintBOB = VB.EffectSpeed + AdditiveBob;
        normalBOB = VB.EffectSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(SprintKey) && isGrounded)
        {
            isSprinting = true;
        }

        if (Input.GetKeyUp(SprintKey))
        {
            isSprinting = false;
        }

        Vector3 move = transform.right * x + transform.forward * z;

        if(isSprinting)
        {
            controller.Move(move * sprintSpeed * Time.deltaTime);
            VB.EffectSpeed = sprintBOB;
        }

        if (!isSprinting)
        {
            controller.Move(move * MovementSpeed * Time.deltaTime);
            VB.EffectSpeed = normalBOB;
        }

        if (Input.GetButtonDown("Jump") && isGrounded && CanJump)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleMovimento : MonoBehaviour
{
    [Header("Movimento")]
    public float mvSpeed = 6f;
    public float mvMultiplier = 10f;
    [SerializeField] float airMultiplier = 0.4f;    

    public float playerHeight = 2f;

    [Header("Jumping")]
    public float jumpForce = 5f;

    [Header("Keybinds")]
    [SerializeField] KeyCode jumpkey = KeyCode.Space;

    [Header("Drag")]
    public float groundDrag = 6f;
    public float airDrag = 1f;
        
    float hMove;
    float vMove;

    bool isGrounded;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight / 2 + 0.01f);

        MyInput();
        ControlDrag();

        if (Input.GetKey(jumpkey) && isGrounded)
        {
            Jump();
        }
    }

    void MyInput()
    {
        hMove = Input.GetAxisRaw("Horizontal");
        vMove = Input.GetAxisRaw("Vertical");

        moveDirection = transform.forward * vMove + transform.right * hMove;
    }

    void ControlDrag()
    {
        if (isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = airDrag;
        }

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (isGrounded)
        {
            rb.AddForce(moveDirection.normalized * mvSpeed * mvMultiplier, ForceMode.Acceleration);
        }
        else if (!isGrounded){
            rb.AddForce(moveDirection.normalized * mvSpeed * airMultiplier, ForceMode.Acceleration);
        }

    }

    void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
}

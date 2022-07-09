using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;

    [SerializeField] private LayerMask ground;
    private bool isGrounded;

    private PlayerControls playerControls;

    private Rigidbody2D playerRigidBody;
    private Collider2D playerCollider;

    private void Awake()
    {
        playerControls = new PlayerControls();
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void FixedUpdate()
    {
        Vector2 moveInput = playerControls.Movement.Move.ReadValue<Vector2>();
        playerRigidBody.velocity = moveInput * speed;

    }

    void Start()
    {
       // playerControls.Movement.Jump.performed += _ => Jump();
    }

    /*
    private void Jump()
    {
        if (isGrounded)
        {
            playerRigidBody.gravityScale = 1;
            playerRigidBody.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
            playerRigidBody.gravityScale = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            Debug.Log(isGrounded);
        }
    }

    
    private void Jump()
    {
        if (isGrounded())
        {
            playerRigidBody.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        }
    }

    private bool isGrounded()
    {
        Vector2 topLeftPoint = transform.position;
        topLeftPoint.x -= playerCollider.bounds.extents.x;
        topLeftPoint.y += playerCollider.bounds.extents.y;

        Vector2 bottomRightPoint = transform.position;
        bottomRightPoint.x += playerCollider.bounds.extents.x;
        bottomRightPoint.y -= playerCollider.bounds.extents.y;

        return Physics2D.OverlapArea(topLeftPoint, bottomRightPoint, ground);

        playerRigidBody.gravityScale = 0;
    }*/

}

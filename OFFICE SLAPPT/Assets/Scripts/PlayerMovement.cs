using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;

    [SerializeField] private LayerMask ground;

    private PlayerControls playerControls;

    private Rigidbody2D rigidBody;
    private Collider2D collider;

    private void Awake()
    {
        playerControls = new PlayerControls();
        rigidBody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    void Start()
    {
        playerControls.MovementMap.Jump.performed += _ => Jump();
    }

    private void Jump()
    {
        if (isGrounded())
        {
            rigidBody.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        }
    }

    private bool isGrounded()
    {
        Vector2 topLeftPoint = transform.position;
        topLeftPoint.x -= collider.bounds.extents.x;
        topLeftPoint.y += collider.bounds.extents.y;

        Vector2 bottomRightPoint = transform.position;
        bottomRightPoint.x += collider.bounds.extents.x;
        bottomRightPoint.y -= collider.bounds.extents.y;

        return Physics2D.OverlapArea(topLeftPoint, bottomRightPoint, ground);
    }

    void Update()
    {
        // Reading Movement Value
        float movementInput = playerControls.MovementMap.Move.ReadValue<float>();

        // Moving the Player
        Vector3 currentPosition = transform.position;
        currentPosition.x += movementInput * speed * Time.deltaTime;
        transform.position = currentPosition; 
    }
}

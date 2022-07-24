using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float defaultSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float sprintMultiplier;

    private PlayerControls playerControls;

    private Rigidbody2D playerRigidBody;

    private void Awake()
    {
        playerControls = new PlayerControls();
        playerRigidBody = GetComponent<Rigidbody2D>();
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
        playerRigidBody.velocity = moveInput * walkSpeed;

        playerControls.Movement.Sprint.performed += _ => Sprint();

        playerControls.Movement.Sprint.canceled += _ => stopSprint();
    }

    private void Sprint()
    {
       walkSpeed = defaultSpeed * sprintMultiplier;
    }

    private void stopSprint()
    {
        walkSpeed = defaultSpeed;
    }

}

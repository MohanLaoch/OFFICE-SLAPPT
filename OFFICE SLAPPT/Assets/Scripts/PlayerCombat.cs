using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    private PlayerControls playerControls;

    private InputAction jab;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();

        jab = playerControls.Combat.Jab;
        jab.Enable();
        jab.performed += Jab;
    }

    private void OnDisable()
    {
        playerControls.Disable();
        jab.Disable();
    }

    private void Jab(InputAction.CallbackContext context)
    {
        Debug.Log("Jab");
    }
}

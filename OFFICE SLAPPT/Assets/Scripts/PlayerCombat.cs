using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;

    public int attackDamage = 20;

    public LayerMask enemyLayers;

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
        Attack();
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyStats>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

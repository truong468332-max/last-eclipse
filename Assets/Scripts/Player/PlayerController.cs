using UnityEngine;
using LastEclipse.Combat;
using LastEclipse.Abilities;

namespace LastEclipse.Player
{
    /// <summary>
    /// Main player controller - Handles movement, combat, and absorption
    /// One-hit-one-kill mechanic
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float dashSpeed = 10f;
        [SerializeField] private float dashCooldown = 0.5f;
        [SerializeField] private float dashDuration = 0.2f;

        private Rigidbody2D rb;
        private PlayerStats stats;
        private AbilityManager abilityManager;
        private DemonAbsorption absorption;
        private MemorySystem memorySystem;

        private Vector2 moveInput;
        private bool isDashing = false;
        private float dashCooldownTimer = 0f;
        private Vector2 facingDirection = Vector2.right;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            stats = GetComponent<PlayerStats>();
            abilityManager = GetComponent<AbilityManager>();
            absorption = GetComponent<DemonAbsorption>();
            memorySystem = GetComponent<MemorySystem>();
        }

        private void Update()
        {
            HandleInput();
            UpdateDashCooldown();
            UpdateFacingDirection();
        }

        private void FixedUpdate()
        {
            HandleMovement();
        }

        private void HandleInput()
        {
            // Movement
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            moveInput = new Vector2(horizontal, vertical).normalized;

            // Dash
            if (Input.GetKeyDown(KeyCode.Space) && dashCooldownTimer <= 0 && !isDashing)
            {
                StartDash();
            }

            // Absorb
            if (Input.GetKeyDown(KeyCode.E))
            {
                TryAbsorb();
            }

            // Memory Vision
            if (Input.GetKeyDown(KeyCode.Q))
            {
                memorySystem.ActivateMemoryVision();
            }
        }

        private void HandleMovement()
        {
            if (isDashing)
            {
                rb.velocity = facingDirection * dashSpeed;
            }
            else
            {
                rb.velocity = moveInput * moveSpeed;
            }
        }

        private void UpdateFacingDirection()
        {
            if (moveInput.magnitude > 0)
            {
                facingDirection = moveInput.normalized;
            }
        }

        private void StartDash()
        {
            isDashing = true;
            dashCooldownTimer = dashCooldown;
            StartCoroutine(DashCoroutine());
        }

        private System.Collections.IEnumerator DashCoroutine()
        {
            yield return new WaitForSeconds(dashDuration);
            isDashing = false;
        }

        private void UpdateDashCooldown()
        {
            if (dashCooldownTimer > 0)
            {
                dashCooldownTimer -= Time.deltaTime;
            }
        }

        private void TryAbsorb()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f);
            foreach (var collider in colliders)
            {
                if (collider.CompareTag("Demon"))
                {
                    absorption.AbsorbDemon(collider.gameObject);
                    return;
                }
            }
        }

        public void TakeDamage(float damage)
        {
            stats.TakeDamage(damage);
            if (stats.health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Debug.Log("Kai died. Restarting level...");
            Time.timeScale = 0f; // Freeze time
            GameManager.Instance.RestartLevel();
        }

        public Vector2 GetFacingDirection() => facingDirection;
        public bool IsDashing() => isDashing;
        public float GetSpeed() => moveSpeed;
    }
}

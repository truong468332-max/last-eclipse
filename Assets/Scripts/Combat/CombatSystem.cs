using UnityEngine;
using LastEclipse.Player;
using LastEclipse.Enemies;

namespace LastEclipse.Combat
{
    /// <summary>
    /// Combat system - One-hit-one-kill mechanics
    /// </summary>
    public class CombatSystem : MonoBehaviour
    {
        [SerializeField] private float attackCooldown = 0.3f;
        [SerializeField] private float attackRange = 1.5f;
        private float attackCooldownTimer = 0f;

        private PlayerController playerController;
        private ParticleSystem hitParticles;

        private void Start()
        {
            playerController = GetComponent<PlayerController>();
        }

        private void Update()
        {
            UpdateCooldown();

            if (Input.GetMouseButtonDown(0))
            {
                Attack();
            }
        }

        private void Attack()
        {
            if (attackCooldownTimer > 0) return;

            Vector2 facingDirection = playerController.GetFacingDirection();

            Collider2D[] hits = Physics2D.OverlapCircleAll(
                (Vector2)transform.position + facingDirection * attackRange,
                attackRange
            );

            foreach (var hit in hits)
            {
                if (hit.CompareTag("Demon"))
                {
                    BaseDemon demon = hit.GetComponent<BaseDemon>();
                    if (demon != null)
                    {
                        demon.TakeDamage(1f); // One-hit-kill
                        OnHit(hit.transform.position);
                    }
                }
            }

            attackCooldownTimer = attackCooldown;
        }

        private void UpdateCooldown()
        {
            if (attackCooldownTimer > 0)
            {
                attackCooldownTimer -= Time.deltaTime;
            }
        }

        private void OnHit(Vector3 hitPosition)
        {
            if (hitParticles != null)
            {
                Instantiate(hitParticles, hitPosition, Quaternion.identity);
            }
            Debug.Log("HIT!");
        }
    }
}

using UnityEngine;

namespace LastEclipse.Enemies
{
    /// <summary>
    /// Ancient Demon - Massive size, boss-level threat, can destroy cities
    /// </summary>
    public class AncientDemon : BaseDemon
    {
        [SerializeField] private float bossHealthMultiplier = 5f;
        [SerializeField] private float specialAttackCooldown = 3f;
        private float specialAttackTimer = 0f;

        private void Start()
        {
            base.Start();
            demonType = DemonType.Ancient;
            speed = 1.5f;
            health = 10f; // Boss HP
            mutationLevel = 1f;
            transform.localScale = Vector3.one * 2f; // Larger size
        }

        protected override void UpdateBehavior()
        {
            if (playerTransform == null) return;

            float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

            if (distanceToPlayer < detectionRange)
            {
                currentState = DemonState.Hunting;
                SlowChase();
                TrySpecialAttack();
            }
            else
            {
                currentState = DemonState.Dormant;
                rb.velocity = Vector2.zero;
            }
        }

        private void SlowChase()
        {
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            rb.velocity = direction * speed;
        }

        private void TrySpecialAttack()
        {
            specialAttackTimer -= Time.deltaTime;
            if (specialAttackTimer <= 0)
            {
                Debug.Log("Ancient Demon uses SPECIAL ATTACK!");
                // Create shockwave
                CreateShockwave();
                specialAttackTimer = specialAttackCooldown;
            }
        }

        private void CreateShockwave()
        {
            // TODO: Implement shockwave effect
            Debug.Log("SHOCKWAVE! Destroys everything in radius!");
        }
    }
}

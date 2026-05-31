using UnityEngine;
using LastEclipse.Player;

namespace LastEclipse.Enemies
{
    /// <summary>
    /// Feral Demon - Lost consciousness, attacks everything, unpredictable
    /// </summary>
    public class FeralDemon : BaseDemon
    {
        private float chaosTimer = 0f;
        private Vector2 chaosDirection;

        private void Start()
        {
            base.Start();
            demonType = DemonType.Feral;
            speed = 4f;
            mutationLevel = 0.3f;
            GenerateChaosDirection();
        }

        protected override void UpdateBehavior()
        {
            if (playerTransform == null) return;

            float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

            if (distanceToPlayer < detectionRange)
            {
                currentState = DemonState.Hunting;
                // Feral demons attack erratically
                if (Random.value > 0.7f)
                {
                    GenerateChaosDirection();
                }
                ChasePlayer();
            }
            else
            {
                currentState = DemonState.Idle;
                // Random wandering
                chaosTimer -= Time.deltaTime;
                if (chaosTimer <= 0)
                {
                    GenerateChaosDirection();
                    chaosTimer = Random.Range(1f, 3f);
                }
                rb.velocity = chaosDirection * speed * 0.5f;
            }
        }

        protected override void ChasePlayer()
        {
            // Erratic movement - not direct chase
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            Vector2 chaos = Random.insideUnitCircle * 0.5f;
            rb.velocity = (direction + chaos) * speed;
        }

        private void GenerateChaosDirection()
        {
            chaosDirection = Random.insideUnitCircle.normalized;
        }
    }
}

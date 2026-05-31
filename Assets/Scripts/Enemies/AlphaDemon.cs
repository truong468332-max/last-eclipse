using UnityEngine;

namespace LastEclipse.Enemies
{
    /// <summary>
    /// Alpha Demon - Intelligent leader, territorial, strategic
    /// </summary>
    public class AlphaDemon : BaseDemon
    {
        [SerializeField] private float territoryRadius = 8f;
        private Vector3 territoryCenter;
        private float patrolTimer = 0f;

        private void Start()
        {
            base.Start();
            demonType = DemonType.Alpha;
            speed = 3.5f;
            mutationLevel = 0.6f;
            territoryCenter = transform.position;
        }

        protected override void UpdateBehavior()
        {
            if (playerTransform == null) return;

            float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);
            float distanceFromTerritory = Vector2.Distance(transform.position, territoryCenter);

            if (distanceToPlayer < detectionRange && distanceFromTerritory < territoryRadius)
            {
                currentState = DemonState.Hunting;
                ChasePlayer();
            }
            else if (distanceFromTerritory > territoryRadius)
            {
                currentState = DemonState.Territorial;
                ReturnToTerritory();
            }
            else
            {
                currentState = DemonState.Idle;
                Patrol();
            }
        }

        protected override void ChasePlayer()
        {
            // Strategic chase - predicts player movement
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            rb.velocity = direction * speed;
        }

        private void ReturnToTerritory()
        {
            Vector2 direction = (territoryCenter - transform.position).normalized;
            rb.velocity = direction * speed;
        }

        private void Patrol()
        {
            patrolTimer -= Time.deltaTime;
            if (patrolTimer <= 0)
            {
                // Patrol around territory
                Vector2 randomPoint = territoryCenter + (Vector3)Random.insideUnitCircle * territoryRadius * 0.5f;
                Vector2 direction = (randomPoint - transform.position).normalized;
                rb.velocity = direction * speed * 0.5f;
                patrolTimer = Random.Range(2f, 4f);
            }
        }
    }
}

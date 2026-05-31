using UnityEngine;
using LastEclipse.Player;
using UnityEngine.AI;

namespace LastEclipse.Enemies
{
    public enum DemonType { Feral, Alpha, Ancient }
    public enum DemonState { Idle, Hunting, Territorial, Dormant }

    /// <summary>
    /// Base class for all demons - Mutated humans and animals
    /// </summary>
    public class BaseDemon : MonoBehaviour
    {
        [SerializeField] public DemonType demonType = DemonType.Feral;
        public DemonState currentState = DemonState.Idle;

        [SerializeField] protected float health = 1f;
        [SerializeField] protected float speed = 3f;
        [SerializeField] protected float attackRange = 1f;
        [SerializeField] protected float detectionRange = 5f;
        [SerializeField] protected float damage = 1f;

        public DemonMemory[] memories;
        public float mutationLevel = 0.5f;

        protected Rigidbody2D rb;
        protected Transform playerTransform;
        protected bool isAlive = true;

        [SerializeField] protected ParticleSystem deathParticles;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
                playerTransform = player.transform;
        }

        private void Update()
        {
            if (!isAlive) return;

            UpdateBehavior();
        }

        protected virtual void UpdateBehavior()
        {
            // Base AI behavior
            float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

            if (distanceToPlayer < detectionRange)
            {
                currentState = DemonState.Hunting;
                ChasePlayer();
            }
            else
            {
                currentState = DemonState.Idle;
                Idle();
            }
        }

        protected virtual void ChasePlayer()
        {
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            rb.velocity = direction * speed;
        }

        protected virtual void Idle()
        {
            rb.velocity = Vector2.zero;
        }

        public virtual void TakeDamage(float dmg)
        {
            health -= dmg;
            if (health <= 0)
            {
                Die();
            }
        }

        public virtual void Die()
        {
            isAlive = false;
            if (deathParticles != null)
            {
                Instantiate(deathParticles, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                PlayerController playerController = collision.GetComponent<PlayerController>();
                if (playerController != null)
                {
                    playerController.TakeDamage(damage);
                }
            }
        }
    }

    [System.Serializable]
    public struct DemonMemory
    {
        public string title;
        public string description;
        public string beforeMutation; // What they were before
    }
}

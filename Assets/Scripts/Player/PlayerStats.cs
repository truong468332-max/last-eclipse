using UnityEngine;

namespace LastEclipse.Player
{
    /// <summary>
    /// Player statistics - Health (1 HP), absorbed powers, memories
    /// </summary>
    public class PlayerStats : MonoBehaviour
    {
        public float health = 1f;
        private float maxHealth = 1f;
        public int absorbedPowers = 0;
        public int memoriesCollected = 0;

        [SerializeField] private ParticleSystem damageParticles;

        private void Start()
        {
            health = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            health -= damage;
            health = Mathf.Max(0, health);

            if (damageParticles != null)
            {
                Instantiate(damageParticles, transform.position, Quaternion.identity);
            }

            Debug.Log($"Kai took {damage} damage. Health: {health}");
        }

        public void AddAbsorbedPower()
        {
            absorbedPowers++;
            Debug.Log($"Powers absorbed: {absorbedPowers}");
        }

        public void AddMemory()
        {
            memoriesCollected++;
            Debug.Log($"Memories collected: {memoriesCollected}");
        }

        public bool IsAlive() => health > 0;
    }
}

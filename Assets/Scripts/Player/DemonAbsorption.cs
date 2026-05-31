using UnityEngine;
using LastEclipse.Enemies;
using LastEclipse.Player;

namespace LastEclipse.Abilities
{
    /// <summary>
    /// Handles demon absorption - Core mechanic
    /// Absorbs powers and memories from defeated demons
    /// </summary>
    public class DemonAbsorption : MonoBehaviour
    {
        [SerializeField] private ParticleSystem absorptionEffect;
        [SerializeField] private float absorptionRange = 2f;

        private PlayerStats playerStats;
        private MemorySystem memorySystem;

        private void Start()
        {
            playerStats = GetComponent<PlayerStats>();
            memorySystem = GetComponent<MemorySystem>();
        }

        public void AbsorbDemon(GameObject demonObject)
        {
            BaseDemon demon = demonObject.GetComponent<BaseDemon>();
            if (demon == null) return;

            Debug.Log($"Absorbing demon: {demon.demonType}");

            // Visual effect
            if (absorptionEffect != null)
            {
                Instantiate(absorptionEffect, transform.position, Quaternion.identity);
            }

            // Absorb power
            AbsorbPower(demon);

            // Absorb memory
            AbsorbMemory(demon);

            // Add stats
            playerStats.AddAbsorbedPower();

            // Destroy demon
            Destroy(demonObject);
        }

        private void AbsorbPower(BaseDemon demon)
        {
            // Different powers based on demon type
            switch (demon.demonType)
            {
                case DemonType.Feral:
                    // Gain speed boost
                    Debug.Log("Gained: Feral Rage (Speed boost)");
                    break;

                case DemonType.Alpha:
                    // Gain strength
                    Debug.Log("Gained: Alpha Dominance (Damage boost)");
                    break;

                case DemonType.Ancient:
                    // Gain special ability
                    Debug.Log("Gained: Ancient Power (Heavy attack)");
                    break;
            }
        }

        private void AbsorbMemory(BaseDemon demon)
        {
            if (demon.memories != null && demon.memories.Length > 0)
            {
                foreach (var memory in demon.memories)
                {
                    memorySystem.AddMemory(memory);
                    playerStats.AddMemory();
                    Debug.Log($"Memory absorbed: {memory.title}");
                }
            }
        }
    }
}

using UnityEngine;

namespace LastEclipse.Factions
{
    /// <summary>
    /// Ash Walkers - Desert survivors
    /// Goal: Hunt demons for resources, survive
    /// </summary>
    public class AshWalkers : Faction
    {
        private void Start()
        {
            factionName = "Ash Walkers";
            description = "Hunt. Scavenge. Survive. That's all that matters.";
            factionColor = new Color(0.8f, 0.6f, 0.2f); // Brown/Gold
            isHostile = false;
        }

        public override void InitiateMission()
        {
            Debug.Log("ASH WALKERS: Hunt demons and gather resources.");
            missionCount++;
        }

        public override void RewardPlayer()
        {
            Debug.Log("ASH WALKERS: Supplies shared. You're one of us now.");
        }
    }
}

using UnityEngine;

namespace LastEclipse.Factions
{
    /// <summary>
    /// Children of Void - Nihilistic cult
    /// Goal: Accelerate world destruction, embrace apocalypse
    /// </summary>
    public class ChildrenOfVoid : Faction
    {
        private void Start()
        {
            factionName = "Children of Void";
            description = "The old world must burn. From ashes rises the new.";
            factionColor = new Color(0.4f, 0f, 0.4f); // Purple/Black
            isHostile = true; // Always hostile
        }

        public override void InitiateMission()
        {
            Debug.Log("CHILDREN OF VOID: Spread chaos. Accelerate the end.");
            missionCount++;
        }

        public override void RewardPlayer()
        {
            Debug.Log("CHILDREN OF VOID: Chaos served. Here's power.");
        }
    }
}

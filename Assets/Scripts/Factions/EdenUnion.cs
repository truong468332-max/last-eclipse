using UnityEngine;

namespace LastEclipse.Factions
{
    /// <summary>
    /// Eden Union - Scientists
    /// Goal: Cure the infection, restore humanity
    /// </summary>
    public class EdenUnion : Faction
    {
        private void Start()
        {
            factionName = "Eden Union";
            description = "Find a cure. Restore civilization. Science will save us.";
            factionColor = new Color(0.2f, 0.8f, 0.2f); // Green
            isHostile = false;
        }

        public override void InitiateMission()
        {
            Debug.Log("EDEN UNION: Collect biological samples from demons.");
            missionCount++;
        }

        public override void RewardPlayer()
        {
            Debug.Log("EDEN UNION: Research data acquired. Here's medical supplies.");
        }
    }
}

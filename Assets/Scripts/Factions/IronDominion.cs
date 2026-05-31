using UnityEngine;

namespace LastEclipse.Factions
{
    /// <summary>
    /// Iron Dominion - Military extremists
    /// Goal: Eliminate all demons and control the world
    /// </summary>
    public class IronDominion : Faction
    {
        private void Start()
        {
            factionName = "Iron Dominion";
            description = "Eliminate all demons. Military power over all.";
            factionColor = new Color(0.5f, 0.5f, 0.5f); // Gray
            isHostile = true; // Can become hostile
        }

        public override void InitiateMission()
        {
            Debug.Log("IRON DOMINION: Exterminate all demons in this sector.");
            missionCount++;
        }

        public override void RewardPlayer()
        {
            Debug.Log("IRON DOMINION: Mission complete. Here's military tech.");
        }
    }
}

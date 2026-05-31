using UnityEngine;

namespace LastEclipse.Factions
{
    /// <summary>
    /// Base faction class - Different factions with different goals
    /// </summary>
    public abstract class Faction : MonoBehaviour
    {
        public string factionName;
        public string description;
        public Color factionColor;

        protected int missionCount = 0;
        protected bool isHostile = false;

        public abstract void InitiateMission();
        public abstract void RewardPlayer();

        public string GetDescription() => description;
        public int GetMissionCount() => missionCount;
        public bool IsHostile() => isHostile;
    }
}

using UnityEngine;
using System.Collections.Generic;

namespace LastEclipse.Story
{
    /// <summary>
    /// Story manager - Handles narrative, choices, and endings
    /// Tracks faction reputation and plot twists
    /// </summary>
    public class StoryManager : MonoBehaviour
    {
        public static StoryManager Instance { get; private set; }

        [System.Serializable]
        public class StoryState
        {
            public int act = 1;
            public int chapter = 1;
            public bool plot_twist_1_revealed = false;
            public bool plot_twist_2_revealed = false;
            public bool plot_twist_3_revealed = false;
        }

        public StoryState story = new StoryState();

        // Faction trust levels (-100 to 100)
        [SerializeField] private float ironDominationTrust = 0f;
        [SerializeField] private float edenUnionTrust = 0f;
        [SerializeField] private float ashWalkersTrust = 0f;
        [SerializeField] private float childrenOfVoidTrust = 0f;

        private List<string> playerChoices = new List<string>();
        private Ending currentEnding = Ending.None;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        public void MakeChoice(string choiceDescription, Faction faction)
        {
            playerChoices.Add(choiceDescription);
            Debug.Log($"Choice made: {choiceDescription}");

            // Update faction trust based on choice
            switch (faction)
            {
                case Faction.IronDominion:
                    ironDominationTrust += 10f;
                    break;
                case Faction.EdenUnion:
                    edenUnionTrust += 10f;
                    break;
                case Faction.AshWalkers:
                    ashWalkersTrust += 10f;
                    break;
                case Faction.ChildrenOfVoid:
                    childrenOfVoidTrust += 10f;
                    break;
            }
        }

        public void RevealPlotTwist(int twistNumber)
        {
            switch (twistNumber)
            {
                case 1:
                    if (!story.plot_twist_1_revealed)
                    {
                        story.plot_twist_1_revealed = true;
                        Debug.Log("PLOT TWIST 1: The Black Rain was created by a pre-war organization!");
                    }
                    break;
                case 2:
                    if (!story.plot_twist_2_revealed)
                    {
                        story.plot_twist_2_revealed = true;
                        Debug.Log("PLOT TWIST 2: Kai is part of that organization!");
                    }
                    break;
                case 3:
                    if (!story.plot_twist_3_revealed)
                    {
                        story.plot_twist_3_revealed = true;
                        Debug.Log("PLOT TWIST 3: The world is in a cycle - destroyed and reborn many times!");
                    }
                    break;
            }
        }

        public void SetEnding(Ending ending)
        {
            currentEnding = ending;
            Debug.Log($"Ending set to: {ending}");
        }

        public Ending GetEnding() => currentEnding;
        public float GetFactionTrust(Faction faction)
        {
            return faction switch
            {
                Faction.IronDominion => ironDominationTrust,
                Faction.EdenUnion => edenUnionTrust,
                Faction.AshWalkers => ashWalkersTrust,
                Faction.ChildrenOfVoid => childrenOfVoidTrust,
                _ => 0f
            };
        }
    }

    public enum Faction
    {
        IronDominion,
        EdenUnion,
        AshWalkers,
        ChildrenOfVoid
    }

    public enum Ending
    {
        None,
        Extermination,    // Destroy all demons
        Fusion,            // Merge with demons
        Restart            // Destroy source of Black Rain
    }
}

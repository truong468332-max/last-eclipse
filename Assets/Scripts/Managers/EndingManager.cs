using UnityEngine;
using UnityEngine.SceneManagement;
using LastEclipse.Story;

namespace LastEclipse
{
    /// <summary>
    /// Ending manager - Handles the three different endings
    /// </summary>
    public class EndingManager : MonoBehaviour
    {
        public static EndingManager Instance { get; private set; }

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

        public void TriggerEnding(Ending endingType)
        {
            Time.timeScale = 0f; // Freeze gameplay

            switch (endingType)
            {
                case Ending.Extermination:
                    ShowExterminationEnding();
                    break;
                case Ending.Fusion:
                    ShowFusionEnding();
                    break;
                case Ending.Restart:
                    ShowRestartEnding();
                    break;
            }

            StoryManager.Instance.SetEnding(endingType);
        }

        private void ShowExterminationEnding()
        {
            Debug.Log("""
            ═══════════════════════════════════════════════════════════
            ENDING 1: EXTERMINATION
            ═══════════════════════════════════════════════════════════

            Every demon is destroyed.
            
            Humanity survives... but the world continues to decay.
            
            The Black Rain may be gone, but its legacy remains.
            
            Cities crumble. Radiation still poisons the earth.
            
            Is this really a victory?
            
            Or just a hollow triumph?
            
            ═══════════════════════════════════════════════════════════
            """);
        }

        private void ShowFusionEnding()
        {
            Debug.Log("""
            ═══════════════════════════════════════════════════════════
            ENDING 2: FUSION
            ═══════════════════════════════════════════════════════════

            Human and demon DNA merge.
            
            A new species emerges from the ashes.
            
            Evolution... or abomination?
            
            The world transforms into something beautiful and terrible.
            
            Kai stands at the apex of this new world.
            
            But at what cost?
            
            ═══════════════════════════════════════════════════════════
            """);
        }

        private void ShowRestartEnding()
        {
            Debug.Log("""
            ═══════════════════════════════════════════════════════════
            ENDING 3: RESTART
            ═══════════════════════════════════════════════════════════

            The source of the Black Rain is destroyed.
            
            The cycle is broken.
            
            Civilization is reset.
            
            New life blooms from the ashes.
            
            But history has a way of repeating itself.
            
            Will humanity make the same mistakes again?
            
            ═══════════════════════════════════════════════════════════
            """);
        }
    }
}

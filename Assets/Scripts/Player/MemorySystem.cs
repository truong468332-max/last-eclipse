using UnityEngine;
using System.Collections.Generic;
using LastEclipse.Enemies;

namespace LastEclipse.Player
{
    /// <summary>
    /// Memory system - Shows demon memories when absorbed
    /// Reveals the truth about the Black Rain
    /// </summary>
    public class MemorySystem : MonoBehaviour
    {
        private List<DemonMemory> collectedMemories = new List<DemonMemory>();
        private bool memoryVisionActive = false;

        [SerializeField] private Canvas memoryCanvas;
        [SerializeField] private Color memoryVisionColor = new Color(0, 1, 0, 0.3f);

        public void AddMemory(DemonMemory memory)
        {
            collectedMemories.Add(memory);
            Debug.Log($"Added memory: {memory.title} - {memory.description}");
        }

        public void ActivateMemoryVision()
        {
            memoryVisionActive = !memoryVisionActive;
            Debug.Log($"Memory Vision: {(memoryVisionActive ? "ON" : "OFF")}");

            if (memoryVisionActive)
            {
                ShowAllMemories();
            }
            else
            {
                HideMemories();
            }
        }

        private void ShowAllMemories()
        {
            foreach (var memory in collectedMemories)
            {
                Debug.Log($"MEMORY: {memory.title}\n{memory.description}");
            }
        }

        private void HideMemories()
        {
            if (memoryCanvas != null)
            {
                memoryCanvas.enabled = false;
            }
        }

        public List<DemonMemory> GetAllMemories() => new List<DemonMemory>(collectedMemories);
        public int GetMemoryCount() => collectedMemories.Count;
    }

    [System.Serializable]
    public struct DemonMemory
    {
        public string title;
        public string description;
        public float timestamp;
        public Sprite memoryImage;
    }
}

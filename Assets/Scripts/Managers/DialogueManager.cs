using UnityEngine;
using System.Collections.Generic;

namespace LastEclipse.Story
{
    /// <summary>
    /// Dialogue manager - Handles dialogue trees and player choices
    /// </summary>
    public class DialogueManager : MonoBehaviour
    {
        public static DialogueManager Instance { get; private set; }

        [System.Serializable]
        public class DialogueNode
        {
            public string speakerName;
            public string text;
            public List<DialogueChoice> choices = new List<DialogueChoice>();
            public bool isEndNode = false;
        }

        [System.Serializable]
        public class DialogueChoice
        {
            public string choiceText;
            public DialogueNode nextNode;
            public Faction faction;
            public int storyImpact;
        }

        private DialogueNode currentNode;
        private bool dialogueActive = false;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        public void StartDialogue(DialogueNode startNode)
        {
            currentNode = startNode;
            dialogueActive = true;
            DisplayCurrentDialogue();
        }

        private void DisplayCurrentDialogue()
        {
            if (currentNode == null) return;

            Debug.Log($"\n--- {currentNode.speakerName} ---\n{currentNode.text}\n");

            if (currentNode.choices.Count > 0)
            {
                for (int i = 0; i < currentNode.choices.Count; i++)
                {
                    Debug.Log($"[{i + 1}] {currentNode.choices[i].choiceText}");
                }
            }

            if (currentNode.isEndNode)
            {
                dialogueActive = false;
                Debug.Log("--- End of Dialogue ---\n");
            }
        }

        public void MakeChoice(int choiceIndex)
        {
            if (choiceIndex < 0 || choiceIndex >= currentNode.choices.Count) return;

            DialogueChoice choice = currentNode.choices[choiceIndex];
            Debug.Log($"You chose: {choice.choiceText}");

            // Register choice in StoryManager
            StoryManager.Instance.MakeChoice(choice.choiceText, choice.faction);

            // Move to next node
            if (choice.nextNode != null)
            {
                currentNode = choice.nextNode;
                DisplayCurrentDialogue();
            }
            else
            {
                dialogueActive = false;
            }
        }

        public bool IsDialogueActive() => dialogueActive;
    }
}

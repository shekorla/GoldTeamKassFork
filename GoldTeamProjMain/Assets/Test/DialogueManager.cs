using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    public Dialogue defaultDialogue; // Default dialogue for NPCs

    void Awake()
    {
        // Singleton pattern to ensure only one instance of DialogueManager exists
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public string[] GetDialogue(Dialogue dialogue)
    {
        if (dialogue != null)
        {
            return dialogue.dialogueLines;
        }
        else
        {
            Debug.LogWarning("Dialogue is not assigned.");
            return new string[0]; // Return an empty array if dialogue is not assigned
        }
    }
}
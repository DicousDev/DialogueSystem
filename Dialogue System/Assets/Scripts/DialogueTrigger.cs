using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueHistory dialogue;

    void Start() 
    {
        DialogueManager.instance.StartConversation(dialogue);
    }
}
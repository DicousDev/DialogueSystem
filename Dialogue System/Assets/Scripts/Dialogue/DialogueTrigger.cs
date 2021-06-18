using UnityEngine;
using DialogueSystem.Manager;
using DialogueSystem.ScriptableObj;

namespace DialogueSystem
{
    public class DialogueTrigger : MonoBehaviour
    {
        [SerializeField] private Dialogue dialogue;

        void Start() 
        {
            DialogueManager.instance.StartConversation(dialogue);
        }
    }
}
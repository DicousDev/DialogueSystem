using UnityEngine;

namespace DialogueSystem.ScriptableObj
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Dialogue", fileName = "New Dialogue")]
    public class Dialogue : ScriptableObject 
    {
        public DialogueConteiner[] dialogue;
    }
}
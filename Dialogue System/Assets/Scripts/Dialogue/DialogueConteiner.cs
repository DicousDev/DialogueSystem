using UnityEngine;
using DialogueSystem.ScriptableObj;

namespace DialogueSystem
{
    [System.Serializable]
    public class DialogueConteiner
    {
        public Talker talker;
        [TextArea]
        public string[] messages;
    } 
}


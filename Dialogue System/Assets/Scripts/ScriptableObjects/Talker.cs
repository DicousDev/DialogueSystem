using UnityEngine;

namespace DialogueSystem.ScriptableObj
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Talker", fileName = "New Talker")]
    public class Talker : ScriptableObject
    {
        public string name;
        public Sprite sprite;
    }
}

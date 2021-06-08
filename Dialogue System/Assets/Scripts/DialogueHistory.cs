using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/DialogueHistory", fileName = "New Dialogue")]
public class DialogueHistory : ScriptableObject 
{
    public Dialogue[] dialogue;
}
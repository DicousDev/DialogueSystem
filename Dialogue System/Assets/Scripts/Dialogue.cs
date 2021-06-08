using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public TalkerSO talker;
    [TextArea]
    public string[] messages;
}
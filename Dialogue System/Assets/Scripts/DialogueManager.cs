using System;
using System.Collections;
using UnityEngine;

public class DialogueManager : MonoBehaviour 
{
    public static DialogueManager instance;
    private DialogueHistory currentDialogue;
    private bool endCurrentTalker = true;
    private bool buttonClicked = false;
    public static event Action<Dialogue> onNewTalker;
    public static event Action onResetText;
    public static event Action<string> onShowMessage;
    public static event Action<bool> onUIState;
    public static event Action onEnd;

    void Awake() 
    {
        instance = this;
    }

    public void ButtonWasClicked() =>
        buttonClicked = true;

    public void StartConversation(DialogueHistory dialogue)
    {
        currentDialogue = dialogue;
        StartCoroutine(StartDialogue());
        onUIState?.Invoke(true);
    }

    IEnumerator StartDialogue()
    {
        for(int i = 0; i < currentDialogue.dialogue.Length; i++)
        {
            onResetText?.Invoke();
            onNewTalker?.Invoke(currentDialogue.dialogue[i]);
            StartCoroutine(ShowDialogue(currentDialogue.dialogue[i].messages));
            yield return new WaitUntil(() => endCurrentTalker);
        }

        currentDialogue = null;
        onUIState?.Invoke(false);
        onEnd?.Invoke();
    }

    IEnumerator ShowDialogue(string[] messages)
    {
        endCurrentTalker = false;

        foreach(var message in messages)
        {
            ShowAllMessage(message);

            yield return new WaitUntil(() => buttonClicked);
        }

        endCurrentTalker = true;
    }

    void ShowAllMessage(string message)
    {
        onShowMessage?.Invoke(message);
        buttonClicked = false;
    }
}
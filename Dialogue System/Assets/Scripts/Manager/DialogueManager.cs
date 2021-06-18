using System;
using System.Collections;
using UnityEngine;
using DialogueSystem.ScriptableObj;

namespace DialogueSystem.Manager
{
    public class DialogueManager : MonoBehaviour 
    {
        public static DialogueManager instance;
        private Dialogue currentDialogue;
        [SerializeField] private float delayLetter = 0.03f;
        private bool endCurrentTalker = true;
        private bool buttonClicked = false;
        public static event Action<DialogueConteiner, Action> onNewTalker;
        public static event Action onResetText;
        public static event Action<string> onShowMessage;
        public static event Action<bool> onUIState;
        public static event Action onEnd;
        public static event Action<bool> onNext;

        void Awake() 
        {
            instance = this;    
        }

        public void ButtonWasClicked() =>
            buttonClicked = true;

        public void StartConversation(Dialogue dialogue)
        {
            currentDialogue = dialogue;
            StartCoroutine(StartDialogue());
            onUIState?.Invoke(true);
            onNext?.Invoke(false);
        }

        IEnumerator StartDialogue()
        {
            for(int i = 0; i < currentDialogue.dialogue.Length; i++)
            {
                bool endNewTalker = false;
                onNext?.Invoke(false);
                onResetText?.Invoke();
                onNewTalker?.Invoke(currentDialogue.dialogue[i], () => endNewTalker = true);
                yield return new WaitUntil(() => endNewTalker);
                StartCoroutine(ShowDialogue(currentDialogue.dialogue[i].messages));
                yield return new WaitUntil(() => endCurrentTalker);
            }

            onUIState?.Invoke(false);
            onEnd?.Invoke();
        }

        IEnumerator ShowDialogue(string[] messages)
        {
            endCurrentTalker = false;

            foreach(var message in messages)
            {
                onNext?.Invoke(false);
                StartCoroutine(ShowAllMessage(message));
                yield return new WaitUntil(() => buttonClicked);
            }

            endCurrentTalker = true;
        }

        IEnumerator ShowAllMessage(string message)
        {
            buttonClicked = false;
            string current = string.Empty;

            for(int i = 0; i < message.Length; i++)
            {
                yield return new WaitForSeconds(delayLetter);
                current += message[i];
                onShowMessage?.Invoke(current);
            }

            onNext?.Invoke(true);
        }
    }
}
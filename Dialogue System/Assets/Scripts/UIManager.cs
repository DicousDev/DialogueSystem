using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour 
{
    public static UIManager instance;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Image characterImage;
    [SerializeField] private GameObject conteinerDialogue;
    private Vector3 positionCharacterStart;

    void OnEnable() 
    {
        DialogueManager.onNewTalker += NewTalker;
        DialogueManager.onShowMessage += ShowText;
        DialogueManager.onResetText += ResetText;
        DialogueManager.onUIState += UIState;
    }

    void OnDestroy() 
    {
        DialogueManager.onNewTalker -= NewTalker;
        DialogueManager.onShowMessage -= ShowText;
        DialogueManager.onResetText -= ResetText;
        DialogueManager.onUIState -= UIState;
    }

    void Awake() 
    {
        instance = this;
        positionCharacterStart = characterImage.rectTransform.localPosition;
    }

    void NewTalker(Dialogue talker)
    {
        characterImage.sprite = talker.talker.sprite;
        nameText.text = talker.talker.name;

        characterImage.rectTransform.localPosition = positionCharacterStart;
        LeanTween.moveX(characterImage.rectTransform, 0, 0.6f).setEase(LeanTweenType.easeSpring);
    }

    void ShowText(string message) =>
        dialogueText.text = message;

    void ResetText() =>
        dialogueText.text = string.Empty;

    void UIState(bool state) =>
        conteinerDialogue.SetActive(state);

}
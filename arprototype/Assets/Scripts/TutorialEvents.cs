using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(TextTutorial))]
public class TutorialEvents : MonoBehaviour
{
    TextTutorial tutorial;
    Text buttonText;
    Button button;

    private void Start() {
        tutorial = GetComponent<TextTutorial>();
        button = tutorial.Button;
        buttonText = button.GetComponentInChildren<Text>();
    }

    public void SetButtonText(string text)
    {
        buttonText.text = text;
    }
    public void HideUIElement(CanvasGroup objectToHide)
    {
        objectToHide.alpha = 0;
        objectToHide.blocksRaycasts = false;
        objectToHide.interactable = false;
    }
    public void DisableObject(GameObject objectToDisable)
    {
        objectToDisable.SetActive(false);
    }
}

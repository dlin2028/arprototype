using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField]
    List<string> TutorialText;

    [SerializeField]
    CrosshairSceneLoader SceneLoaderButton;

    [SerializeField]
    string SceneToLoad;

    private Text text;
    private Button button;
    private Button doneButton;
    private Text doneButtonText;
    private int currentStep;
    void Start()
    {
        text = GetComponentInChildren<Text>();
        button = GetComponent<Button>();

        doneButton = SceneLoaderButton.gameObject.GetComponent<Button>();
        doneButtonText = SceneLoaderButton.gameObject.GetComponentInChildren<Text>();
        text.text = TutorialText[currentStep++];

        doneButton.onClick.AddListener(() =>
        {
            if(currentStep == TutorialText.Count)
            {
                doneButtonText.text = "Calibrate";
                doneButton.onClick.AddListener(() => SceneLoaderButton.LoadCHSceneAdditiveAsync(SceneToLoad));
                gameObject.SetActive(false);
                currentStep++;
            }
            else if(currentStep <= TutorialText.Count)
            {
                text.text = TutorialText[currentStep++];
            }
        });
    }

}

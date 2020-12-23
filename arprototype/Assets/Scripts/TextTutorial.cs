using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TextTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    
    [Serializable]
    public class Step
    {
        public string Text;
        public UnityEvent OnBeginStep;
    }

    [SerializeField]
    List<Step> Steps;

    [SerializeField]
    public Button Button;

    [SerializeField]
    public int currentStep;

    private Text text;
    private UnityAction currentEvent;
    void Start()
    {
        text = GetComponentInChildren<Text>();

        currentEvent = () => {}; //empty function
        Button.onClick.AddListener(() =>
        {
            if(currentStep >= Steps.Count)
            {
                text.text = Steps[currentStep - 1].Text;
                Steps[currentStep - 1].OnBeginStep.Invoke();
                Debug.Log("No more steps left, repeating last step...");
                return;
            }
            text.text = Steps[currentStep].Text;
            Steps[currentStep].OnBeginStep.Invoke();
            currentStep++;
        });
        Button.onClick.Invoke();
    }
}

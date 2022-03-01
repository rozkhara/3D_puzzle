using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour
{
    [SerializeField]
    private Text tutorialText;

    public GameObject swipe;

    [SerializeField]
    private string[] texts;


    private void Update()
    {
        if (swipe.GetComponent<Swipe>().rotationCheck == true)
        {
            tutorialText.text = texts[0];
        }
        if (swipe.GetComponent<Swipe>().moveCheck == true)
        {
            tutorialText.text = texts[1];
        }
    }
}

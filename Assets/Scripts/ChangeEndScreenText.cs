using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeEndScreenText : MonoBehaviour
{
    private string secondsSurvived;
    public Text secondsText;
    public TextMeshProUGUI won;
    //for win screen
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;

    public void Start()
    {
        text1.enabled = true;
        text2.enabled = true;
        secondsText.enabled = true;
        secondsSurvived = CrossSceneInformation.secondsSurvived;

     //   print("Seconds Survived " + secondsSurvived);
    //    secondsText = GameObject.FindWithTag("menutext").GetComponent<TextMeshPro>();
        secondsText.text = secondsSurvived;
        if (CrossSceneInformation.won)
        {
            text1.enabled = false;
            text2.enabled = false;
            secondsText.enabled = false;
            won.text = "You won!";
            CrossSceneInformation.won = false;
        }
    }
}

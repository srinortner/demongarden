using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeEndScreenText : MonoBehaviour
{
    private string secondsSurvived;
    public Text secondsText;
    public Text won;

    public void Start()
    {
        secondsSurvived = CrossSceneInformation.secondsSurvived;
     //   print("Seconds Survived " + secondsSurvived);
    //    secondsText = GameObject.FindWithTag("menutext").GetComponent<TextMeshPro>();
        secondsText.text = secondsSurvived;
        if (CrossSceneInformation.won)
        {
            won.text = "You won!";
        }
    }
}

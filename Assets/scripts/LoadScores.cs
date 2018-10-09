using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LoadScores : MonoBehaviour
{
    private Text score;

    // Use this for initialization
    void Start ()
    {
        score = this.GetComponent<Text>();
        if (this.name == "Score1")
        {
            score.text = PlayerPrefs.GetFloat("Highscore1").ToString("F2");
        }
        else if (this.name == "Score2")
        {
            score.text = PlayerPrefs.GetFloat("Highscore2").ToString("F2");
        }
        else if (this.name == "Score3")
        {
            score.text = PlayerPrefs.GetFloat("Highscore3").ToString("F2");
        }
        else if (this.name == "Score4")
        {
            score.text = PlayerPrefs.GetFloat("Highscore4").ToString("F2");
        }
        else if (this.name == "Score5")
        {
            score.text = PlayerPrefs.GetFloat("Highscore5").ToString("F2");
        }

    }
	
}

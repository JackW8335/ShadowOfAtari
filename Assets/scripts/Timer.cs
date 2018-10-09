using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float time = 0;
    public float bestTime = 0;

    private Text score;

    public BossBehaviour boss;

    // Use this for initialization
    void Start()
    {
        time = 0;
   
        score = this.GetComponent<Text>();


        score.text = time.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        score.text = time.ToString("F1");

        if (boss.health <= 0)
        {
            SetScore();
        }
    }

    void SetScore()
    {
        if (PlayerPrefs.GetFloat("Highscore1") > 0)
        {
            if (time < PlayerPrefs.GetFloat("Highscore1"))
            {
                PlayerPrefs.SetFloat("Highscore1", time);
                return;
            }
        }
        else
        {
            PlayerPrefs.SetFloat("Highscore1", time);
            return;
        }

        if (PlayerPrefs.GetFloat("Highscore2") > 0)
        {
            if (time < PlayerPrefs.GetFloat("Highscore2"))
            {
                PlayerPrefs.SetFloat("Highscore2", time);
                return;
            }
        }
        else
        {
            PlayerPrefs.SetFloat("Highscore2", time);
            return;
        }

        if (PlayerPrefs.GetFloat("Highscore3") > 0)
        {
            if (time < PlayerPrefs.GetFloat("Highscore3"))
            {
                PlayerPrefs.SetFloat("Highscore3", time);
                return;
            }
        }
        else
        {
            PlayerPrefs.SetFloat("Highscore3", time);
            return;
        }

        if (PlayerPrefs.GetFloat("Highscore4") > 0)
        {
            if (time < PlayerPrefs.GetFloat("Highscore4"))
            {
                PlayerPrefs.SetFloat("Highscore4", time);
                return;
            }
        }
        else
        {
            PlayerPrefs.SetFloat("Highscore4", time);
        }

        if (PlayerPrefs.GetFloat("Highscore5") > 0)
        {
            if (time < PlayerPrefs.GetFloat("Highscore5"))
            {
                PlayerPrefs.SetFloat("Highscore5", time);
                return;
            }
        }
        else
        {
            PlayerPrefs.SetFloat("Highscore5", time);
            return;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void Start()
    {
        Screen.SetResolution(192, 160, true);
    }
	public void PlayGame()
    {
        PlayerPrefs.SetFloat("Highscore1", 0);
        PlayerPrefs.SetFloat("Highscore2", 0);
        PlayerPrefs.SetFloat("Highscore3", 0);
        PlayerPrefs.SetFloat("Highscore4", 0);
        PlayerPrefs.SetFloat("Highscore5", 0);


        SceneManager.LoadScene("scene1");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("scene1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

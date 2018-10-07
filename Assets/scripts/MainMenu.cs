using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame()
    {
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

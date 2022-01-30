using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void PlayGame()
    {
        if (PlayerPrefs.GetInt("LastCompletedLevel") != PlayerPrefs.GetInt("AmountOfLevels"))
        {
            PlayerPrefs.SetInt("PlayingLevel", PlayerPrefs.GetInt("LastCompletedLevel") + 1);
            SceneManager.LoadScene(PlayerPrefs.GetInt("LastCompletedLevel") + 1);
        }
        else
        {
            PlayerPrefs.SetInt("PlayingLevel", PlayerPrefs.GetInt("LastCompletedLevel"));
            SceneManager.LoadScene(PlayerPrefs.GetInt("LastCompletedLevel"));
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        Pause.paused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuScene");
    }

    public void NextLevel()
    {
        if (PlayerPrefs.GetInt("LastCompletedLevel") != PlayerPrefs.GetInt("AmountOfLevels"))
        {
            PlayerPrefs.SetInt("PlayingLevel", PlayerPrefs.GetInt("LastCompletedLevel") + 1);
            SceneManager.LoadScene(PlayerPrefs.GetInt("LastCompletedLevel") + 1);
        }
        else
        {
            PlayerPrefs.SetInt("PlayingLevel", PlayerPrefs.GetInt("LastCompletedLevel"));
            SceneManager.LoadScene("EndScreen");
        }
    }

    public void Restart()
    {
        Pause.paused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void SetSelectedButton(string button)
    {
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(GameObject.Find(button), new BaseEventData(eventSystem));
    }

    public void ResetStats()
    {
        PlayerPrefs.SetInt("LastCompletedLevel", 0);
        PlayerPrefs.SetInt("PlayingLevel", 1);
        PlayerPrefs.SetInt("LevelUnlocked", 1);
        for (int i = 1; i <= PlayerPrefs.GetInt("AmountOfLevels"); i++)
        {
            PlayerPrefs.SetInt("FastestTimeLevel" + i, 0);
            PlayerPrefs.SetInt("HighestStarsLevel" + i, 0);
        }
    }
}

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
            SceneManager.LoadScene(PlayerPrefs.GetInt("LastCompletedLevel"));
        }
    }


    public void SetSelectedButton()
    {
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(GameObject.Find("Play Button"), new BaseEventData(eventSystem));
    }

    public void ResetStats()
    {
        PlayerPrefs.SetInt("LastCompletedLevel", 0);
        PlayerPrefs.SetInt("PlayingLevel", 0);
        PlayerPrefs.SetInt("LevelUnlocked", 1);
    }
}

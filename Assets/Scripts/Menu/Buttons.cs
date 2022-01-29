using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void PlayGame()
    {
        PlayerPrefs.SetInt("PlayingLevel", PlayerPrefs.GetInt("LastCompletedLevel") + 1);
        SceneManager.LoadScene(PlayerPrefs.GetInt("LastCompletedLevel") + 1);
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
        SceneManager.LoadScene(PlayerPrefs.GetInt("LastCompletedLevel") + 1);
    }


    public void SetSelectedButton()
    {
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(GameObject.Find("Play Button"), new BaseEventData(eventSystem));
    }

}

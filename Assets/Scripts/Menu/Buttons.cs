using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetSelectedButton()
    {
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(GameObject.Find("Play Button"), new BaseEventData(eventSystem));
    }
}

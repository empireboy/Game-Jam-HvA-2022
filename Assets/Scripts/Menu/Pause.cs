using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pause : MonoBehaviour
{
    public static bool paused;
    [SerializeField] private GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused) Resume();
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        SetSelectedButton("Resume Button");
        Time.timeScale = 0;
        paused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        paused = false;
    }
    public void SetSelectedButton(string button)
    {
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(GameObject.Find(button), new BaseEventData(eventSystem));
    }
}

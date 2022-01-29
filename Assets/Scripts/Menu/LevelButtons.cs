using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButtons : MonoBehaviour
{
    [SerializeField] private int level;
    private LevelSelecter levelSelecter;
    private Image buttonImage;
    private UnityEngine.UI.Button button;
    private void Awake()
    {
        levelSelecter = GetComponentInParent<LevelSelecter>();
        buttonImage = GetComponent<Image>();
        button = GetComponent<UnityEngine.UI.Button>();
    }
    public void UnlockedCheck()
    {
        if (PlayerPrefs.GetInt("LevelUnlocked" + level) == 1)//makes the button green (and enables the button) if unlocked
        {
            buttonImage.color = Color.white;
            button.enabled = true;
        }
    }

    public void SetSelectedButton()
    {
        if (level == 1) //sets the first level as selected button
        {
            var eventSystem = EventSystem.current;
            eventSystem.SetSelectedGameObject(gameObject, new BaseEventData(eventSystem));
        }
    }

    public void PlayLevel()
    {
        PlayerPrefs.SetInt("PlayerLevel", level);
        SceneManager.LoadScene("Level " + level);
    }
    
}

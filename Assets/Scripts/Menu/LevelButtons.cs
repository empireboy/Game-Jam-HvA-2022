using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButtons : MonoBehaviour
{
    [SerializeField] private int level;
    [SerializeField] private GameObject star1, star2, star3;
    private Image buttonImage;
    private UnityEngine.UI.Button button;
    private Color color;
    private void Awake()
    {
        PlayerPrefs.SetInt("LevelUnlocked" + 1,1);
        buttonImage = GetComponent<Image>();
        color = buttonImage.color;
        button = GetComponent<UnityEngine.UI.Button>();
    }

    private void Start()
    {
        switch (PlayerPrefs.GetInt("HighestStarsLevel" + level))
        {
            case 1:
                star1.GetComponent<LevelEndStars>().Activate();
                break;

            case 2:
                star1.GetComponent<LevelEndStars>().Activate();
                star2.GetComponent<LevelEndStars>().Activate();
                break;

            case 3:
                star1.GetComponent<LevelEndStars>().Activate();
                star2.GetComponent<LevelEndStars>().Activate();
                star3.GetComponent<LevelEndStars>().Activate();
                break;
        }
    }

    public void Update()
    { 
        UnlockedCheck();
    }
    public void UnlockedCheck()
    {
        if (PlayerPrefs.GetInt("LevelUnlocked") >= level)//makes the button green (and enables the button) if unlocked
        {
            buttonImage.color = Color.white;
            button.enabled = true;
        }
        else
        {
            buttonImage.color = color;
            button.enabled = false;
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
        PlayerPrefs.SetInt("PlayingLevel", level);
        SceneManager.LoadScene("Level " + level);
    }
    
}

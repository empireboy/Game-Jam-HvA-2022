using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private GameObject star1, star2, star3;
    [SerializeField] private TextMeshProUGUI timeText, fastestTimeText;
    [SerializeField] private GameObject mainMenuButton;
    [SerializeField] private GameObject nextLevelButton;
    [SerializeField] private GameObject creditsButton;
    private int time;

    void Start()
    {
        time = (int)PlayerTimer._timeSpentInLevel;
        if (time < PlayerPrefs.GetInt("FastestTimeLevel" + PlayerPrefs.GetInt("LastCompletedLevel")) || PlayerPrefs.GetInt("FastestTimeLevel" + PlayerPrefs.GetInt("LastCompletedLevel")) == 0) PlayerPrefs.SetInt("FastestTimeLevel" + PlayerPrefs.GetInt("LastCompletedLevel"), time);

        if(time > 3600)//if someone has managed to play for more than an hour
        {
            int hours = TimeSpan.FromSeconds(time).Hours;
            int minutes = TimeSpan.FromSeconds(time).Minutes;
            int seconds = TimeSpan.FromSeconds(time).Seconds;
            timeText.text = "Your time: " + hours + ":" + minutes+ ":" + seconds;
        }
        else
        {
            int minutes = TimeSpan.FromSeconds(time).Minutes;
            int seconds = TimeSpan.FromSeconds(time).Seconds;
            timeText.text = "Your time: " + minutes + ":" + seconds;
        }

        if (PlayerPrefs.GetInt("FastestTimeLevel" + PlayerPrefs.GetInt("LastCompletedLevel")) > 3600)
        {
            int hours = TimeSpan.FromSeconds(PlayerPrefs.GetInt("FastestTimeLevel" + PlayerPrefs.GetInt("LastCompletedLevel"))).Hours;
            int minutes = TimeSpan.FromSeconds(PlayerPrefs.GetInt("FastestTimeLevel" + PlayerPrefs.GetInt("LastCompletedLevel"))).Minutes;
            int seconds = TimeSpan.FromSeconds(PlayerPrefs.GetInt("FastestTimeLevel" + PlayerPrefs.GetInt("LastCompletedLevel"))).Seconds;
            fastestTimeText.text = "Your time: " + hours + ":" + minutes + ":" + seconds;
        }
        else
        {
            int minutes = TimeSpan.FromSeconds(PlayerPrefs.GetInt("FastestTimeLevel" + PlayerPrefs.GetInt("LastCompletedLevel"))).Minutes;
            int seconds = TimeSpan.FromSeconds(PlayerPrefs.GetInt("FastestTimeLevel" + PlayerPrefs.GetInt("LastCompletedLevel"))).Seconds;
            fastestTimeText.text = "Your fastest time: " + minutes + ":" + seconds;
        }
        //timeText.text = "Your time: " + ((int)PlayerTimer._timeSpentInLevel).ToString() + " seconds";
        //fastestTimeText.text = "Your fastest time: " + PlayerPrefs.GetInt("FastestTimeLevel" + PlayerPrefs.GetInt("LastCompletedLevel")).ToString() + " seconds";


        if (PlayerTimer.starsEarned > PlayerPrefs.GetInt("HighestStarsLevel" + PlayerPrefs.GetInt("LastCompletedLevel"))) PlayerPrefs.SetInt("HighestStarsLevel" + PlayerPrefs.GetInt("LastCompletedLevel"), PlayerTimer.starsEarned);

        switch (PlayerTimer.starsEarned)
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

        if (PlayerPrefs.GetInt("LastCompletedLevel") != PlayerPrefs.GetInt("AmountOfLevels")) 
        { 
            mainMenuButton.SetActive(false);
            nextLevelButton.SetActive(false);
            creditsButton.SetActive(true);
        }
        else
        {
            mainMenuButton.SetActive(true);
            nextLevelButton.SetActive(true);
            creditsButton.SetActive(false);
        }
    }
}

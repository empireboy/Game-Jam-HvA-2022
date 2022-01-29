using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private GameObject star1, star2, star3;
    [SerializeField] private TextMeshProUGUI timeText, fastestTimeText;
    private int time;

    void Start()
    {
        time = (int)PlayerTimer._timeSpentInLevel;
        if (time < PlayerPrefs.GetInt("FastestTimeLevel" + PlayerPrefs.GetInt("LastCompletedLevel")) || PlayerPrefs.GetInt("FastestTimeLevel" + PlayerPrefs.GetInt("LastCompletedLevel")) == 0) PlayerPrefs.SetInt("FastestTimeLevel" + PlayerPrefs.GetInt("LastCompletedLevel"), time);

        if(time > 3600)//if someone has managed to play for more than an hour
        {

        }
        else
        {

        }
        timeText.text = "Your time: " + ((int)PlayerTimer._timeSpentInLevel).ToString() + " seconds";
        fastestTimeText.text = "Your fastest time: " + PlayerPrefs.GetInt("FastestTimeLevel" + PlayerPrefs.GetInt("LastCompletedLevel")).ToString() + " seconds";

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
    }
}

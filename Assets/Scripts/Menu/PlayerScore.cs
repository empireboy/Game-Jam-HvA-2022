using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] GameObject star1, star2, star3;
    private TextMeshProUGUI text;
    private int time;

    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        time = (int)PlayerTimer._timeSpentInLevel;
        if (time < PlayerPrefs.GetInt("FastestTimeLevel" + PlayerPrefs.GetInt("LastCompletedLevel"))) PlayerPrefs.SetInt("FastestTimeLevel" + PlayerPrefs.GetInt("LastCompletedLevel"), time);
        text.text = ((int)PlayerTimer._timeSpentInLevel).ToString() + " seconds";

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

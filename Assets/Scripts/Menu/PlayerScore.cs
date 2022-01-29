using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] GameObject star1, star2, star3;
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
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

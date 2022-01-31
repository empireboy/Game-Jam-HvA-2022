using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTimer : MonoBehaviour
{
    float timeSpentInLevel;
    [SerializeField] int threeStarTime, twoStarTime;

    public static float _timeSpentInLevel;
    public static int starsEarned;

    // Update is called once per frame
    void Update()
    {
        timeSpentInLevel += Time.deltaTime;
    }

    public void EndLevel()
    {
        if (timeSpentInLevel < threeStarTime)
        {
            starsEarned = 3;
        }
        else if (timeSpentInLevel < twoStarTime)
        {
            starsEarned = 2;
        }
        else starsEarned = 1;

        _timeSpentInLevel = timeSpentInLevel;
    }
}

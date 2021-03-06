using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmountOfLevels : MonoBehaviour
{
    public int amountOfLevels;
    void Start()
    {
        //run at the start of the entire game
        if (PlayerPrefs.GetInt("PlayingLevel") == 0) PlayerPrefs.SetInt("PlayingLevel", 1);
        if (PlayerPrefs.GetInt("LevelUnlocked") == 0) PlayerPrefs.SetInt("LevelUnlocked", 1);
        PlayerPrefs.SetInt("AmountOfLevels", amountOfLevels);
    }
}

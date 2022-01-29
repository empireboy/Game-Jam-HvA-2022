using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] Finish _p1;
    [SerializeField] Finish _p2;
    void Update()
    {
        if (_p1._playerHasFinished && _p2._playerHasFinished || Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.SetInt("LastCompletedLevel", PlayerPrefs.GetInt("PlayingLevel"));
            if(PlayerPrefs.GetInt("LastCompletedLevel") != PlayerPrefs.GetInt("AmountOfLevels")) PlayerPrefs.SetInt("levelUnlocked" + (PlayerPrefs.GetInt("PlayingLevel") + 1), 1);
            SceneManager.LoadScene("LevelEndMenuScene");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] Finish _p1;
    [SerializeField] Finish _p2;

    PlayerTimer playerTimer;

    private void Start()
    {
        playerTimer = FindObjectOfType<PlayerTimer>();
    }

    void Update()
    {
        if (_p1._playerHasFinished && _p2._playerHasFinished)
        {
            playerTimer.EndLevel();
            PlayerPrefs.SetInt("LastCompletedLevel", PlayerPrefs.GetInt("PlayingLevel"));
            if(PlayerPrefs.GetInt("LastCompletedLevel") != PlayerPrefs.GetInt("AmountOfLevels")) PlayerPrefs.SetInt("LevelUnlocked", PlayerPrefs.GetInt("LevelUnlocked") + 1);
            Debug.Log(PlayerPrefs.GetInt("LevelUnlocked"));
            SceneManager.LoadScene("LevelEndMenuScene");
        }
    }
}

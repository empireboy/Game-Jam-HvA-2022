using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LastLevel : MonoBehaviour
{
    [SerializeField] private string lastLevelText;
    private void Start()
    {
        if (PlayerPrefs.GetInt("LastCompletedLevel") + 1 != PlayerPrefs.GetInt("AmountOfLevels")) GetComponentInChildren<TextMeshProUGUI>().text = lastLevelText;
    }
}

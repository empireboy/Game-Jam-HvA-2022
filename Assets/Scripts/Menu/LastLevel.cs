using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LastLevel : MonoBehaviour
{
    [SerializeField] private string lastLevelText;
    private string otherLevelText;
    private void Start()
    {
        otherLevelText = GetComponentInChildren<TextMeshProUGUI>().text;
        if (PlayerPrefs.GetInt("LastCompletedLevel") != PlayerPrefs.GetInt("AmountOfLevels")) GetComponentInChildren<TextMeshProUGUI>().text = otherLevelText;
        else GetComponentInChildren<TextMeshProUGUI>().text = lastLevelText;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelecter : MonoBehaviour
{
    public void OnOpen()
    {
        LevelButtons buttons = GetComponentInChildren<LevelButtons>();
        buttons.UnlockedCheck();
        buttons.SetSelectedButton();
    }
}

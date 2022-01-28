using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelecter : MonoBehaviour
{
    [HideInInspector] public bool[] levelsUnlocked = { false, true, false, false, false, false };
    public void updateUnlockedLevel(int levelUnlocked)
    {
        levelsUnlocked[levelUnlocked] = true;
    }

    public void CheckForUnlockedLevels()
    {
        GetComponentInChildren<LevelButtons>().UnlockedCheck();
    }
}

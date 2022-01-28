using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtons : MonoBehaviour
{
    [SerializeField] private int level;
    private LevelSelecter levelSelecter;
    private Image buttonImage;
    private Button button;
    private void Awake()
    {
        levelSelecter = GetComponentInParent<LevelSelecter>();
        buttonImage = GetComponent<Image>();
        button = GetComponent<Button>();
    }
    public void UnlockedCheck()
    {
        if (levelSelecter.levelsUnlocked[level])
        {
            buttonImage.color = Color.white;
            button.enabled = true;
        }
    }
    
}

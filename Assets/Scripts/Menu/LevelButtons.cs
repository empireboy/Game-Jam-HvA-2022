using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
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
        if (levelSelecter.levelsUnlocked[level])//makes the button green (and enables the button) if unlocked
        {
            buttonImage.color = Color.white;
            button.enabled = true;
        }

        if (level == 1) //sets the first level as selected button
        {
            var eventSystem = EventSystem.current;
            eventSystem.SetSelectedGameObject(this.gameObject, new BaseEventData(eventSystem));
        }
    }

    public void PlayLevel()
    {
        if (level == 1) SceneManager.LoadScene("SampleScene");
        if (level == 2) SceneManager.LoadScene("SampleScene");
        if (level == 3) SceneManager.LoadScene("SampleScene");
        if (level == 4) SceneManager.LoadScene("SampleScene");
        if (level == 5) SceneManager.LoadScene("SampleScene");
    }
    
}

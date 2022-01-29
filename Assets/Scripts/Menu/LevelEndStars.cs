using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEndStars : MonoBehaviour
{
    [SerializeField] private Sprite deactiveStar;
    [SerializeField] private Sprite activeStar;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }
    public void Activate()
    {
        image.sprite = activeStar;
    }
    public void Deactivate()
    {
        image.sprite = deactiveStar;
    }
}

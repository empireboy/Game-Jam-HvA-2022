using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndStars : MonoBehaviour
{
    [SerializeField] private Sprite deactiveStar;
    [SerializeField] private Sprite activeStar;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Activate()
    {
        spriteRenderer.sprite = activeStar;
    }
    public void Deactivate()
    {
        spriteRenderer.sprite = deactiveStar;
    }
}

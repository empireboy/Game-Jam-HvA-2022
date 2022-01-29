using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControllerMenu : MonoBehaviour
{
    private TextMeshProUGUI text;
    [SerializeField] [Range(0,1)] private float fadeSpeed;
    [SerializeField] private float fadeTime;
    private float fadeTimer;
    [SerializeField] private GameObject nextMenu;
    void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        fadeTimer = fadeTime;
    }

    void Update()
    {
        Fade();
        fadeTimer -= Time.deltaTime;
        if (fadeTimer <= 0) NextMenu();
        if (Input.anyKey) NextMenu();
    }

    public void Fade()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - fadeSpeed * Time.deltaTime);
    }

    public void NextMenu()
    {
        nextMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }
}

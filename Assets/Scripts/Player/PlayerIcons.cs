using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PlayerIcons : MonoBehaviour
{
    private Image icon;
    private TextMeshProUGUI text;

    private Transform target;

    [SerializeField] private Vector3 offset = Vector3.zero;

    [SerializeField] private float fadeDelay = 4f;
    [SerializeField] private float fadeMultiplier = 1f;

    [SerializeField] private Sprite keyboard = null;
    [SerializeField] private Sprite controller = null;

    private void Awake()
    {
        icon = GetComponentInChildren<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        StartCoroutine(FadeOut());    
    }

    private void Update()
    {
        if (!target)
            return;

        this.transform.position = Camera.main.WorldToScreenPoint(target.position) + offset;
    }

    private IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(fadeDelay);

        for (float i = 1; i >= 0; i -= Time.deltaTime * fadeMultiplier)
        {
            icon.color = new Color(1, 1, 1, i);
            text.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }

    public void ChangeIcon(PlayerSlot slot, ControllerType type, Transform parent, float gravityScale)
    {
        if(parent.gameObject.name == "Player One")
            text.text = "Player 1";
        else if(parent.gameObject.name == "Player Two")
            text.text = "Player 2";

        if (type == ControllerType.Keyboard)
            icon.sprite = keyboard;
        else
            icon.sprite = controller;

        target = parent;
        offset *= gravityScale;
    }
}

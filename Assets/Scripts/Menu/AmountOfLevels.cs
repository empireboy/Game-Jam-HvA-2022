using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmountOfLevels : MonoBehaviour
{
    public int amountOfLevels;
    void Start()
    {
        PlayerPrefs.SetInt("AmountOfLevels", amountOfLevels);
    }
}

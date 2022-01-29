using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] Finish _p1;
    [SerializeField] Finish _p2;
    void Update()
    {
        if (_p1._playerHasFinished && _p2._playerHasFinished)
        {
            SceneManager.LoadScene("LevelEndMenuScene");
        }
    }
}

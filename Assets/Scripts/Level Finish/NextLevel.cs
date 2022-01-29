using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] Finish _p1;
    [SerializeField] Finish _p2;
    [SerializeField] GameObject winScreen;
    // Start is called before the first frame update
    void Start()
    {
        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_p1._playerHasFinished && _p2._playerHasFinished)
        {
            Debug.Log("Level Complete");
            winScreen.SetActive(true);
        }
    }
}

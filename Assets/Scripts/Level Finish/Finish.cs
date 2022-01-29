using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] bool _playerOne;
    [SerializeField] bool _playerTwo;

    [HideInInspector] public bool _playerHasFinished;
   

    // Start is called before the first frame update
    void Start()
    {
        _playerHasFinished = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_playerOne && collision.CompareTag("Player"))
        {
            _playerHasFinished = true;
        }

        if (_playerTwo && collision.CompareTag("Player2"))
        {
            _playerHasFinished = true;
        }
            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_playerOne && collision.CompareTag("Player"))
        {
            _playerHasFinished = false;
        }

        if (_playerTwo && collision.CompareTag("Player2"))
        {
            _playerHasFinished = false;
        }
    }
}

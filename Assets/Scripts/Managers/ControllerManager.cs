using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    private string[] _controllers;

    private int _amountConnectedControllers = 0;
    private int _currentlyConnected = 99;

    private GameObject _warning = null;

    [SerializeField] private GameObject _NoControllerWarning = null;

    [SerializeField] private bool _giveWarning = true;

    // Update is called once per frame
    void Update()
    {
        _controllers = new string[0];
        _controllers = Input.GetJoystickNames();

        _amountConnectedControllers = 0;

        for (int i = 0; i < _controllers.Length; i++)
        {
            if (_controllers[i] != "")
                _amountConnectedControllers++;
        }

        if (_amountConnectedControllers != _currentlyConnected)
        {
            SetPlayerControllers();
            _currentlyConnected = _amountConnectedControllers;
        }
    }

    private void SetPlayerControllers()
    {
        InputController playerOne = GameObject.Find("Player One").GetComponent<InputController>();
        InputController playerTwo = GameObject.Find("Player Two").GetComponent<InputController>();

        switch (_amountConnectedControllers)
        {
            case 0:

                // Give error that not enough controllers are connected.
                playerOne._currentCType = ControllerType.Keyboard;

                if (playerOne._currentPlayer != PlayerSlot.none)
                    playerOne._currentPlayer = PlayerSlot.none;

                if (!_giveWarning)
                    return;

                Transform canvas = GameObject.Find("Canvas").transform;
                _warning = Instantiate(_NoControllerWarning, canvas.position, Quaternion.identity);
                _warning.transform.parent = canvas;

                break;

            case 1:

                // Player one uses Keyboard and mouse
                playerOne._currentCType = ControllerType.Keyboard;

                if(playerOne._currentPlayer != PlayerSlot.none)
                    playerOne._currentPlayer = PlayerSlot.none;

                // Player two uses controller
                if (playerTwo._currentCType != ControllerType.Controller)
                    playerTwo._currentCType = ControllerType.Controller;

                if (playerTwo._currentPlayer != PlayerSlot.none)
                    break;

                if (playerOne._currentPlayer != PlayerSlot.PlayerOne)
                    playerTwo._currentPlayer = PlayerSlot.PlayerOne;
                else 
                    playerTwo._currentPlayer = PlayerSlot.PlayerTwo;

                if (_controllers[0].ToLower().Contains("xbox"))
                    playerTwo._controller = Controller.xbox;
                else
                    playerTwo._controller = Controller.playstation;

                break;

            case 2:

                // Player one uses controller
                if (playerOne._currentCType != ControllerType.Controller)
                    playerOne._currentCType = ControllerType.Controller;

                if (playerTwo._currentPlayer != PlayerSlot.PlayerOne)
                {
                    playerOne._currentPlayer = PlayerSlot.PlayerOne;

                    if (_controllers[0].ToLower().Contains("xbox"))
                        playerOne._controller = Controller.xbox;
                    else
                        playerOne._controller = Controller.playstation;
                }
                else
                {
                    playerOne._currentPlayer = PlayerSlot.PlayerTwo;

                    if (_controllers[1].ToLower().Contains("xbox"))
                        playerOne._controller = Controller.xbox;
                    else
                        playerOne._controller = Controller.playstation;
                }

                

                // Player two uses controller
                if (playerTwo._currentCType != ControllerType.Controller)
                    playerTwo._currentCType = ControllerType.Controller;

                if (playerTwo._currentPlayer != PlayerSlot.none)
                    break;

                if (playerOne._currentPlayer != PlayerSlot.PlayerOne)
                {
                    playerTwo._currentPlayer = PlayerSlot.PlayerOne;

                    if (_controllers[0].ToLower().Contains("xbox"))
                        playerTwo._controller = Controller.xbox;
                    else
                        playerTwo._controller = Controller.playstation;
                }
                else
                {
                    playerTwo._currentPlayer = PlayerSlot.PlayerTwo;

                    if (_controllers[1].ToLower().Contains("xbox"))
                        playerTwo._controller = Controller.xbox;
                    else
                        playerTwo._controller = Controller.playstation;
                }

                break;
        }

        if (_amountConnectedControllers == 0)
            return;

        Destroy(_warning);
        playerOne.SpawnIcon();
        playerTwo.SpawnIcon();
    }
}

public enum Controller { xbox, playstation } 

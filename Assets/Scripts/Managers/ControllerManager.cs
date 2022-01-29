using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    private string[] _controllers;

    private int _amountConnectedControllers = 0;
    private int _currentlyConnected = 0;

    ControllerType playerOneCType, playerTwoCType;

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
            SetPlayerControllers();

        Debug.Log("Amount controllers connected: " + _amountConnectedControllers);
    }

    private void SetPlayerControllers()
    {
        InputController playerOne = GameObject.Find("Player One").GetComponent<InputController>();
        InputController playerTwo = GameObject.Find("Player Two").GetComponent<InputController>();

        switch (_amountConnectedControllers)
        {
            case 0:

                // Give error that not enough controllers are connected.

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
                    return;

                if (playerOne._currentPlayer != PlayerSlot.PlayerOne)
                    playerTwo._currentPlayer = PlayerSlot.PlayerOne;
                else 
                    playerTwo._currentPlayer = PlayerSlot.PlayerTwo;

                break;
            case 2:

                // Player one uses controller
                if (playerOne._currentCType != ControllerType.Controller)
                    playerOne._currentCType = ControllerType.Controller;

                if (playerTwo._currentPlayer != PlayerSlot.PlayerOne)
                    playerOne._currentPlayer = PlayerSlot.PlayerOne;
                else
                    playerOne._currentPlayer = PlayerSlot.PlayerTwo;

                // Player two uses controller
                if (playerTwo._currentCType != ControllerType.Controller)
                    playerTwo._currentCType = ControllerType.Controller;

                if (playerTwo._currentPlayer != PlayerSlot.none)
                    return;

                if (playerOne._currentPlayer != PlayerSlot.PlayerOne)
                    playerTwo._currentPlayer = PlayerSlot.PlayerOne;
                else
                    playerTwo._currentPlayer = PlayerSlot.PlayerTwo;

                break;
        }
    }
}

using UnityEngine;

[RequireComponent(typeof(CharacterController2D))]
public class InputController : MonoBehaviour
{
    public ControllerType _currentCType = ControllerType.none;
    public PlayerSlot _currentPlayer = PlayerSlot.none;

    private CharacterController2D cc;

    private void Awake()
    {
        cc = GetComponent<CharacterController2D>();
    }

    public void SetSettings(ControllerType type, PlayerSlot slot)
    {
        _currentCType = type;
        _currentPlayer = slot;
    }

    private void Update()
    {
        switch (_currentCType)
        {
            case ControllerType.Controller:

                switch (_currentPlayer)
                {
                    case PlayerSlot.PlayerOne:
                        cc.SetAxis(Input.GetAxis("ControllerOne_Horizontal"), Input.GetAxisRaw("ControllerOne_Jump"));
                        break;

                    case PlayerSlot.PlayerTwo:
                        cc.SetAxis(Input.GetAxis("ControllerTwo_Horizontal"), Input.GetAxisRaw("ControllerTwo_Jump"));
                        break;
                }

                break;

            case ControllerType.Keyboard:
                cc.SetAxis(Input.GetAxis("Keyboard_Horizontal"), Input.GetAxisRaw("Keyboard_Jump"));
                break;

            case ControllerType.none:
                return;
        }
    }
}

public enum ControllerType { Keyboard, Controller, none }
public enum PlayerSlot { PlayerOne, PlayerTwo, none }

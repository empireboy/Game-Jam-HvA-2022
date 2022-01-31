using UnityEngine;

[RequireComponent(typeof(CharacterController2D))]
public class InputController : MonoBehaviour
{
    public ControllerType _currentCType = ControllerType.none;
    public PlayerSlot _currentPlayer = PlayerSlot.none;
    public Controller _controller = Controller.xbox;

    private CharacterController2D cc;

    [SerializeField] private GameObject _icon = null;

    private GameObject _lastIcon = null;

    private void Awake()
    {
        cc = GetComponent<CharacterController2D>();
    }

    public void SpawnIcon()
    {
        if(_lastIcon)
            Destroy(_lastIcon);

        PlayerIcons icons = Instantiate(_icon, transform.position, Quaternion.identity).GetComponent<PlayerIcons>();
        icons.gameObject.transform.parent = GameObject.Find("Canvas").transform;
        icons.ChangeIcon(_currentPlayer, _currentCType, this.transform, GetComponent<Rigidbody2D>().gravityScale);

        _lastIcon = icons.gameObject;
        Destroy(_lastIcon, 6f);
    }

    private void Update()
    {
        switch (_currentCType)
        {
            case ControllerType.Controller:

                switch (_currentPlayer)
                {
                    case PlayerSlot.PlayerOne:
                        if (_controller == Controller.xbox)
                            cc.SetAxis(Input.GetAxis("ControllerOne_Horizontal"), Input.GetAxisRaw("ControllerOne_Jump"));
                        else
                            cc.SetAxis(Input.GetAxis("ControllerOne_Horizontal"), Input.GetAxisRaw("ControllerOne_Jump_Playstation"));
                        break;

                    case PlayerSlot.PlayerTwo:
                        if (_controller == Controller.xbox)
                            cc.SetAxis(Input.GetAxis("ControllerTwo_Horizontal"), Input.GetAxisRaw("ControllerTwo_Jump"));
                        else
                            cc.SetAxis(Input.GetAxis("ControllerTwo_Horizontal"), Input.GetAxisRaw("ControllerTwo_Jump_Playstation"));
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

using UnityEngine;

public class MagnetInput : MonoBehaviour
{
    [SerializeField]
    private GameObject _target;

    private MagnetMovement _magnetMovement;
    private MagnetMechanic _magnetMechanic;
    private InputController _inputController;

    private void Awake()
    {
        _magnetMovement = GetComponent<MagnetMovement>();
        _magnetMechanic = GetComponent<MagnetMechanic>();

        _inputController = _target.GetComponent<InputController>();
    }

    private void Update()
    {
        float angle = 0;

        switch (_inputController._currentCType)
        {
            case ControllerType.Controller:

                switch (_inputController._currentPlayer)
                {
                    case PlayerSlot.PlayerOne:


                        if (_inputController._controller == Controller.playstation)
                        {
                            angle = Mathf.Atan2(Input.GetAxis("ControllerOne_Vertical_Right_Playstation"), Input.GetAxis("ControllerOne_Horizontal_Right_Playstation")) * Mathf.Rad2Deg;

                            if (Input.GetKey(KeyCode.Joystick1Button5))
                            {
                                _magnetMechanic.Push();
                            }
                            else if (Input.GetKey(KeyCode.Joystick1Button4))
                            {
                                _magnetMechanic.Pull();
                            }
                            else
                            {
                                _magnetMechanic.ReleaseMagnetism();
                            }

                            _magnetMechanic.UpdateInput(Camera.main.WorldToScreenPoint(transform.position + new Vector3(Input.GetAxis("ControllerOne_Horizontal_Right_Playstation"), Input.GetAxis("ControllerOne_Vertical_Right_Playstation"), 0) * 10));
                        }
                        else
                        {
                            angle = Mathf.Atan2(Input.GetAxis("ControllerOne_Vertical_Right"), Input.GetAxis("ControllerOne_Horizontal_Right")) * Mathf.Rad2Deg;

                            if (Input.GetKey(KeyCode.Joystick1Button5))
                            {
                                _magnetMechanic.Push();
                            }
                            else if (Input.GetKey(KeyCode.Joystick1Button4))
                            {
                                _magnetMechanic.Pull();
                            }
                            else
                            {
                                _magnetMechanic.ReleaseMagnetism();
                            }

                            _magnetMechanic.UpdateInput(Camera.main.WorldToScreenPoint(transform.position + new Vector3(Input.GetAxis("ControllerOne_Horizontal_Right"), Input.GetAxis("ControllerOne_Vertical_Right"), 0) * 10));
                        }

                        break;

                    case PlayerSlot.PlayerTwo:

                        if (_inputController._controller == Controller.playstation)
                        {
                            angle = Mathf.Atan2(Input.GetAxis("ControllerTwo_Vertical_Right_Playstation"), Input.GetAxis("ControllerTwo_Horizontal_Right_Playstation")) * Mathf.Rad2Deg;

                            if (Input.GetKey(KeyCode.Joystick2Button5))
                            {
                                _magnetMechanic.Push();
                            }
                            else if (Input.GetKey(KeyCode.Joystick2Button4))
                            {
                                _magnetMechanic.Pull();
                            }
                            else
                            {
                                _magnetMechanic.ReleaseMagnetism();
                            }

                            _magnetMechanic.UpdateInput(Camera.main.WorldToScreenPoint(transform.position + new Vector3(Input.GetAxis("ControllerTwo_Horizontal_Right_Playstation"), Input.GetAxis("ControllerTwo_Vertical_Right_Playstation"), 0) * 10));
                        }
                        else
                        {
                            angle = Mathf.Atan2(Input.GetAxis("ControllerTwo_Vertical_Right"), Input.GetAxis("ControllerTwo_Horizontal_Right")) * Mathf.Rad2Deg;

                            if (Input.GetKey(KeyCode.Joystick2Button5))
                            {
                                _magnetMechanic.Push();
                            }
                            else if (Input.GetKey(KeyCode.Joystick2Button4))
                            {
                                _magnetMechanic.Pull();
                            }
                            else
                            {
                                _magnetMechanic.ReleaseMagnetism();
                            }

                            _magnetMechanic.UpdateInput(Camera.main.WorldToScreenPoint(transform.position + new Vector3(Input.GetAxis("ControllerTwo_Horizontal_Right"), Input.GetAxis("ControllerTwo_Vertical_Right"), 0) * 10));
                        }

                        break;
                }

                break;

            case ControllerType.Keyboard:

                Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(_target.transform.position);
                angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

                if (Input.GetMouseButton(0))
                {
                    _magnetMechanic.Push();
                }
                else if (Input.GetMouseButton(1))
                {
                    _magnetMechanic.Pull();
                }
                else
                {
                    _magnetMechanic.ReleaseMagnetism();
                }

                _magnetMechanic.UpdateInput(Input.mousePosition);

                break;

            case ControllerType.none:
                return;
        }

        _magnetMovement.Snap(_target.transform.position, angle, 1f);
    }
}
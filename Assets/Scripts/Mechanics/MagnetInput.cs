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

                        angle = Mathf.Atan2(Input.GetAxis("ControllerOne_Vertical_Right"), Input.GetAxis("ControllerOne_Horizontal_Right")) * Mathf.Rad2Deg;
                        Debug.Log(angle);

                        break;

                    case PlayerSlot.PlayerTwo:

                        angle = Mathf.Atan2(Input.GetAxis("ControllerTwo_Vertical_Right"), Input.GetAxis("ControllerTwo_Horizontal_Right")) * Mathf.Rad2Deg;

                        break;
                }

                break;

            case ControllerType.Keyboard:

                Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(_target.transform.position);
                angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

                break;

            case ControllerType.none:
                return;
        }

        _magnetMovement.Snap(_target.transform.position, angle, 1f);
    }
}
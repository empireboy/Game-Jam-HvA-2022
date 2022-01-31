using UnityEngine;

public class Button : MonoBehaviour
{
    private int amountOfBoxes;
    [SerializeField] GameObject actionObject;
    [SerializeField] AudioSource pressSound;

    [SerializeField] private bool _upsideDown = false;

    private float _pressedY = 0;
    private float _normalY = 0;

    private bool _pushedIn = false;

    private void Start()
    {
        _normalY = transform.position.y;

        if(_upsideDown)
            _pressedY = _normalY + .1f;
        else
            _pressedY = _normalY - .1f;
    }

    private void Update()
    {
        if(_pushedIn)
            transform.position = new Vector2(transform.position.x, Mathf.Lerp(transform.position.y, _pressedY, Time.deltaTime * 2));
        else
            transform.position = new Vector2(transform.position.x, Mathf.Lerp(transform.position.y, _normalY, Time.deltaTime * 2));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "LittleBox")
        {
            amountOfBoxes++;

            if (amountOfBoxes >= 2)
            {
                Activate();
            }
        }

        if(collision.gameObject.tag == "BigBox")
        {
            Activate();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LittleBox")
        {
            amountOfBoxes--;

            if(amountOfBoxes < 2)
            {
                Deactivate();
            }
        }

        if (collision.gameObject.tag == "BigBox")
        {
            Deactivate();
        }

    }

    private void Activate()
    {
        if(actionObject.gameObject.tag == "Door")
        {
            pressSound.Play();
            actionObject.GetComponent<Door>().Activate();
            _pushedIn = true;
        }
    }

    private void Deactivate()
    {
        if (actionObject.gameObject.tag == "Door")
        {
            actionObject.GetComponent<Door>().Deactivate();
            _pushedIn = false;
        }
    }
}

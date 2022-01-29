using UnityEngine;

public class Button : MonoBehaviour
{
    private int amountOfBoxes;
    [SerializeField] GameObject actionObject;

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
            
    }

    private void Activate()
    {
        if(actionObject.gameObject.tag == "Door")
        {
            actionObject.GetComponent<Door>().Activate();
        }
    }

    private void Deactivate()
    {
        if (actionObject.gameObject.tag == "Door")
        {
            actionObject.GetComponent<Door>().Deactivate();
        }
    }
}

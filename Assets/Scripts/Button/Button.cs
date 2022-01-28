using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private int amountOfBoxes;
    [SerializeField] GameObject actionObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        amountOfBoxes++;

        if(collision.gameObject.tag == "LittleBox" && amountOfBoxes >= 2)
        {
            Activate();
        }
    }

    private void Activate()
    {
        if(actionObject.gameObject.tag == "Door")
        {
            actionObject.GetComponent<Door>().Move();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    BoxPhysics boxPhysics;
    GameObject box;
    private bool _boxOnRails;
    // Start is called before the first frame update
    void Start()
    {
        _boxOnRails = false;
        movementSpeed /= 100f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box") || collision.CompareTag("LittleBox") || collision.CompareTag("BigBox"))
        {
            boxPhysics = collision.GetComponent<BoxPhysics>();
            box = collision.gameObject;
            boxPhysics._onRails = true;
            _boxOnRails = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box") || collision.CompareTag("LittleBox") || collision.CompareTag("BigBox"))
        {
            boxPhysics = collision.GetComponent<BoxPhysics>();
            boxPhysics._onRails = false;
            _boxOnRails = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (_boxOnRails)
        {
            RailMovement();
        }
    }

    private void RailMovement()
    {
        box.transform.position = new Vector3(box.transform.position.x + movementSpeed, box.transform.position.y, box.transform.position.z);

        if(box.transform.position.x > transform.position.x + (GetComponent<Collider2D>().bounds.size.x / 2) || box.transform.position.x < transform.position.x - (GetComponent<Collider2D>().bounds.size.x / 2))
        {
            movementSpeed *= -1;
        }
    }
}

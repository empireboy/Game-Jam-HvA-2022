using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPhysics : MonoBehaviour
{
    public bool _isBig;
    public bool _isPushed;
    public bool _isPulled;

    private Rigidbody2D rb;
    private float normalGravity;

    void Start()
    {
        _isPushed = false;
        _isPulled = false;
        rb = GetComponent<Rigidbody2D>();
        normalGravity = rb.gravityScale;

    }

    // Update is called once per frame
    void Update()
    {
        //if the full box is lower then 0, gravity is downwards
        if (transform.position.y < -transform.lossyScale.y)
            normalGravity = 1f;

        //if the full box is higher then 0, gravity is upwards
        if (transform.position.y > +transform.lossyScale.y)
            normalGravity = -1f;

        //Box doesn't have gravity when being pushed or pulled
        if (_isPulled || _isPushed)
        {
            rb.gravityScale = 0;
        }
        else rb.gravityScale = normalGravity;
    }
}


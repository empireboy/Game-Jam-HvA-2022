using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPhysics : MonoBehaviour
{
    public bool _isBig;
    public bool _isPushed;
    public bool _isPulled;
    public bool _onRails;
    public bool _canGoThroughOrbit;
    [SerializeField] AudioSource boxHit;

    private Rigidbody2D rb;
    private float normalGravity;

    void Start()
    {
        _isPushed = false;
        _isPulled = false;
        rb = GetComponent<Rigidbody2D>();
        normalGravity = rb.gravityScale;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Button")
            boxHit.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //if the full box is lower then 0, gravity is downwards
        if (transform.position.y < -(transform.lossyScale.y/2))
            normalGravity = 1f;

        //if the full box is higher then 0, gravity is upwards
        if (transform.position.y > +(transform.lossyScale.y/2))
            normalGravity = -1f;

        //Box doesn't have gravity when being pushed or pulled

        if (_isPulled || _isPushed || _onRails)
        {
            rb.gravityScale = 0;
        }
        else rb.gravityScale = normalGravity;

        if (!_canGoThroughOrbit)
        {
            if (normalGravity == 1)
            {
                transform.position = new Vector3(transform.position.x, Mathf.Min(transform.position.y, 0), transform.position.z);

                if (transform.position.y >= 0)
                    rb.velocity *= new Vector3(1, 0, 1);
            }
            else if (normalGravity == -1)
            {
                transform.position = new Vector3(transform.position.x, Mathf.Max(transform.position.y, 0), transform.position.z);

                if (transform.position.y <= 0)
                    rb.velocity *= new Vector3(1, 0, 1);
            }
        }
    }
}

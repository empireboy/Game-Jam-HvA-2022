using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(CharacterController2D), typeof(Rigidbody2D))]
public class AnimationController : MonoBehaviour
{
    private Animator _anim;
    private CharacterController2D _cc;
    private Rigidbody2D _rb;

    [SerializeField] private float _velocityThreshold = .8f;

    private bool grounded   = false;
    private bool moving     = false;
    private bool jumping    = false;
    private bool falling    = false;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _cc = GetComponent<CharacterController2D>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        grounded = _cc.grounded;
        moving = (_rb.velocity.x > _velocityThreshold || _rb.velocity.x < -_velocityThreshold);

        if (_rb.gravityScale > 0)
        {
            jumping = (_rb.velocity.y > 0 && !grounded);
            falling = (_rb.velocity.y <= 0 && !grounded);
        }
        else if (_rb.gravityScale < 0)
        {
            jumping = (_rb.velocity.y < 0 && !grounded);
            falling = (_rb.velocity.y >= 0 && !grounded);
        }

        if(moving && !_anim.GetBool("Moving") && _cc.horizontal != 0)
            _anim.SetBool("Moving", true);
        else if(!moving && _anim.GetBool("Moving") && _cc.horizontal == 0)
            _anim.SetBool("Moving", false);

        if(jumping)
            _anim.SetBool("Jumping", true);
        else if (!jumping)
            _anim.SetBool("Jumping", false);

        if (falling)
            _anim.SetBool("Falling", true);
        else if (!falling)
            _anim.SetBool("Falling", false);

        if (grounded)
            _anim.SetBool("Grounded", true);
        else if (!grounded)
            _anim.SetBool("Grounded", false);
    }
}

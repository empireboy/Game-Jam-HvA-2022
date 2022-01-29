using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    [SerializeField] public float _jumpForce = 400f;
    [SerializeField] private float _moveSpeed = 40f;
    [SerializeField] private float _fallMultiplier = 2.5f;
    [SerializeField] private float _lowJumpMultiplier = 2f;
    [SerializeField] AudioSource jumpSound;
 
    [Range(0, .3f)] [SerializeField] private float _movementSmoothing = .05f;

    [SerializeField] private LayerMask _whatIsGround;

    [SerializeField] private Transform _groundCheck;

    const float _groundedRadius = .1f;

    private Rigidbody2D _rb;

    private Vector3 _velocity = Vector3.zero;

    private bool _facingRight = true;
    private bool canMove = true;
    private bool jump = false;
    private bool canJump = true;

    public float horizontal = 0;

    private float vertical = 0;
    
    public bool grounded = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (vertical > 0 && canJump)
        {
            jump = true;
            canJump = false;
        }

        if (vertical == 0)
            canJump = true;

        JumpModifier();
    }

    private void FixedUpdate()
    {
        GroundCheck();

        if (canMove)
            Move(horizontal * Time.fixedDeltaTime * _moveSpeed, jump);

        jump = false;
    }

    private void JumpModifier()
    {
        if (_rb.gravityScale > 0)
        {
            if (_rb.velocity.y < 0)
                _rb.velocity += Vector2.up * Physics2D.gravity.y * (_fallMultiplier - 1) * Time.deltaTime;
            else if (_rb.velocity.y > 0 && vertical == 0)
                _rb.velocity += Vector2.up * Physics2D.gravity.y * (_lowJumpMultiplier - 1) * Time.deltaTime;
        }
        else if (_rb.gravityScale < 0)
        {
            if (_rb.velocity.y > 0)
                _rb.velocity += (Vector2.up * Physics2D.gravity.y * (_fallMultiplier - 1) * Time.deltaTime) * _rb.gravityScale;
            else if (_rb.velocity.y < 0 && vertical == 0)
                _rb.velocity += (Vector2.up * Physics2D.gravity.y * (_lowJumpMultiplier - 1) * Time.deltaTime) * _rb.gravityScale;
        }
    }

    private void GroundCheck()
    {
        grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundCheck.position, _groundedRadius, _whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                grounded = true;
            }
        }
    }

    private void Move(float move, bool jump)
    {
        Vector3 targetVelocity = new Vector2(move * 10f, _rb.velocity.y);
        _rb.velocity = Vector3.SmoothDamp(_rb.velocity, targetVelocity, ref _velocity, _movementSmoothing);

        if (move > 0 && !_facingRight)
            Flip();
        else if (move < 0 && _facingRight)
            Flip();

        if (grounded && jump)
        {
            grounded = false;
            jumpSound.Play();
            _rb.velocity = new Vector2(_rb.velocity.x, 0);
            _rb.AddForce(new Vector2(0f, _jumpForce * _rb.gravityScale));
        }
    }

    private void Flip()
    {
        _facingRight = !_facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void SetAxis(float h, float v)
    {
        horizontal = h;
        vertical = v;
    }
}

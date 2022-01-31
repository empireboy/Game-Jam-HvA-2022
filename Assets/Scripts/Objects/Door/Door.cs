using UnityEngine;

public class Door : MonoBehaviour
{
    enum Movement { non_specified, Up, Down }
    [Tooltip("If up or down is selected the door will go that way no matter where it is positioned")]
    [SerializeField] Movement movement;

    Rigidbody2D rigidbody2D;
    private int gravityScale = 1;

    // Start is called before the first frame update
    void Start()
    {
        movement = Movement.non_specified;

        rigidbody2D = GetComponent<Rigidbody2D>();

        if (transform.position.y < 0)
            gravityScale = -1;

        if (movement == Movement.Up)
            gravityScale = -1;
        else if (movement == Movement.Down)
            gravityScale = 1;
    }

    public void Activate()
    {
        rigidbody2D.gravityScale = gravityScale;
    }

    public void Deactivate()
    {
        rigidbody2D.gravityScale = -gravityScale;
    }
}

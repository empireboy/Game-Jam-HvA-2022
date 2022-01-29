using UnityEngine;

public class MagnetMechanic : MonoBehaviour
{
    public float magneticForcePush;
    public float magneticForcePull;
    public float mouseForcePush = 10f;
    public float mouseForcePull = 5f;
    public float maxDistance = 10f;
    public float distanceFromMagnet = 2f;
    public float closeDistanceFactor = 0.9f;
    public float closeDistanceThreshold;
    public float mouseDistanceThreshold;

    public Sprite magnetPushSprite;
    public Sprite magnetPullSprite;

    [SerializeField]
    private ParticleSystem _pushParticleSystemLeft;

    [SerializeField]
    private ParticleSystem _pushParticleSystemRight;

    [SerializeField]
    private ParticleSystem _pullParticleSystemLeft;

    [SerializeField]
    private ParticleSystem _pullParticleSystemRight;

    private States _state;
    private GameObject _hitObject;
    private Rigidbody2D _hitRigidbody;
    private SpriteRenderer _spriteRenderer;
    private Vector3 _currentVectorToMagnet;
    private Vector3 _currentVectorToMouse;

    public enum States
    {
        None,
        Push,
        Pull
    }

    public void Push()
    {
        if (_state == States.None)
        {
            _spriteRenderer.sprite = magnetPullSprite;

            _pushParticleSystemLeft.Play();
            _pushParticleSystemRight.Play();
            _pullParticleSystemLeft.Stop();
            _pullParticleSystemRight.Stop();

            _state = States.Push;
        }

        _spriteRenderer.sprite = magnetPushSprite;

        if (_hitObject)
            return;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);

        if (!hit)
            return;

        _hitObject = hit.transform.gameObject;

        if (!_hitObject.CompareTag("BigBox"))
        {
            _hitObject = null;
            return;
        }

        _hitRigidbody = _hitObject.GetComponent<Rigidbody2D>();

        _hitObject.GetComponent<BoxPhysics>()._isPushed = true;
    }

    public void Pull()
    {
        if (_state == States.None)
        {
            _spriteRenderer.sprite = magnetPullSprite;

            _pullParticleSystemLeft.Play();
            _pullParticleSystemRight.Play();
            _pushParticleSystemLeft.Stop();
            _pushParticleSystemRight.Stop();

            _state = States.Pull;
        }

        if (_hitObject)
            return;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);

        if (!hit)
            return;

        _hitObject = hit.transform.gameObject;

        if (!_hitObject.CompareTag("BigBox"))
        {
            _hitObject = null;
            return;
        }

        _hitRigidbody = _hitObject.GetComponent<Rigidbody2D>();

        _hitObject.GetComponent<BoxPhysics>()._isPulled = true;
    }

    public void ReleaseMagnetism()
    {
        _state = States.None;
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Push();
        }
        else if (Input.GetMouseButton(1))
        {
            Pull();
        }
        else
        {
            if (_hitObject)
            {
                _hitObject.GetComponent<BoxPhysics>()._isPulled = false;
                _hitObject.GetComponent<BoxPhysics>()._isPushed = false;
            }

            _pushParticleSystemLeft.Stop();
            _pushParticleSystemRight.Stop();
            _pullParticleSystemLeft.Stop();
            _pullParticleSystemRight.Stop();

            _hitObject = null;
            _hitRigidbody = null;
            _state = States.None;
        }
    }

    private void FixedUpdate()
    {
        if (!_hitObject)
            return;

        float distance = Vector2.Distance(transform.position, _hitObject.transform.position);

        if (distance >= maxDistance)
        {
            _hitObject = null;

            return;
        }

        float force = (_state == States.Push) ? magneticForcePush : magneticForcePull;

        force = (_state == States.Push) ? -force : force;

        if (_hitRigidbody)
        {
            _currentVectorToMagnet = -(_hitObject.transform.position - transform.position + -transform.forward * distanceFromMagnet).normalized * force;
            _currentVectorToMouse = (Input.mousePosition - Camera.main.WorldToScreenPoint(_hitObject.transform.position)).normalized;

            _currentVectorToMouse *= (_state == States.Push) ? mouseForcePush : mouseForcePull;

            _hitRigidbody.AddForce(_currentVectorToMagnet);
            _hitRigidbody.AddForce(_currentVectorToMouse);

            if (distance <= mouseDistanceThreshold)
                _hitRigidbody.velocity *= closeDistanceFactor;
        }
    }

    private void OnDrawGizmos()
    {
        if (_currentVectorToMagnet == null)
            return;

        if (_currentVectorToMouse == null)
            return;

        if (!_hitObject)
            return;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(_hitObject.transform.position, _currentVectorToMagnet);

        Gizmos.color = Color.green;
        Gizmos.DrawRay(_hitObject.transform.position, _currentVectorToMouse);
    }
}
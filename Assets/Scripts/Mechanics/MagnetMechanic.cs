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
    private Vector3 _input;

    public enum States
    {
        None,
        Push,
        Pull
    }

    public void Push()
    {
        if (_state != States.Push)
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
        {
            _hitObject.GetComponent<BoxPhysics>()._isPushed = true;
            _hitObject.GetComponent<BoxPhysics>()._isPulled = false;

            if (_hitObject.GetComponent<BoxPhysics>()._isPulled)
                _hitObject.GetComponent<BoxPhysics>()._canGoThroughOrbit = true;

            return;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);

        if (!hit)
            return;

        _hitObject = hit.transform.gameObject;

        if (!_hitObject.CompareTag("BigBox") && !_hitObject.CompareTag("LittleBox"))
        {
            _hitObject = null;
            return;
        }

        _hitRigidbody = _hitObject.GetComponent<Rigidbody2D>();

        _hitObject.GetComponent<BoxPhysics>()._isPushed = true;

        if (_hitObject.GetComponent<BoxPhysics>()._isPulled)
            _hitObject.GetComponent<BoxPhysics>()._canGoThroughOrbit = true;
    }

    public void Pull()
    {
        if (_state != States.Pull)
        {
            _spriteRenderer.sprite = magnetPullSprite;

            _pullParticleSystemLeft.Play();
            _pullParticleSystemRight.Play();
            _pushParticleSystemLeft.Stop();
            _pushParticleSystemRight.Stop();

            _state = States.Pull;
        }

        if (_hitObject)
        {
            _hitObject.GetComponent<BoxPhysics>()._isPulled = true;
            _hitObject.GetComponent<BoxPhysics>()._isPushed = false;

            if (_hitObject.GetComponent<BoxPhysics>()._isPushed)
                _hitObject.GetComponent<BoxPhysics>()._canGoThroughOrbit = true;

            return;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);

        if (!hit)
            return;

        _hitObject = hit.transform.gameObject;

        if (!_hitObject.CompareTag("BigBox") && !_hitObject.CompareTag("LittleBox"))
        {
            _hitObject = null;
            return;
        }

        _hitRigidbody = _hitObject.GetComponent<Rigidbody2D>();

        _hitObject.GetComponent<BoxPhysics>()._isPulled = true;

        if (_hitObject.GetComponent<BoxPhysics>()._isPushed)
            _hitObject.GetComponent<BoxPhysics>()._canGoThroughOrbit = true;
    }

    public void ReleaseMagnetism()
    {
        if (_hitObject)
        {
            _hitObject.GetComponent<BoxPhysics>()._isPulled = false;
            _hitObject.GetComponent<BoxPhysics>()._isPushed = false;
            _hitObject.GetComponent<BoxPhysics>()._canGoThroughOrbit = false;
        }

        _pushParticleSystemLeft.Stop();
        _pushParticleSystemRight.Stop();
        _pullParticleSystemLeft.Stop();
        _pullParticleSystemRight.Stop();

        _hitObject = null;
        _hitRigidbody = null;
        _state = States.None;
    }

    public void UpdateInput(Vector3 input)
    {
        _input = input;
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (!_hitObject)
            return;

        float distance = Vector2.Distance(transform.position, _hitObject.transform.position);

        if (distance >= maxDistance)
        {
            _hitObject.GetComponent<BoxPhysics>()._isPulled = false;
            _hitObject.GetComponent<BoxPhysics>()._isPushed = false;
            _hitObject = null;

            return;
        }

        float force = (_state == States.Push) ? magneticForcePush : magneticForcePull;

        force = (_state == States.Push) ? -force : force;

        if (_hitRigidbody)
        {
            _currentVectorToMagnet = -(_hitObject.transform.position - transform.position + -transform.forward * distanceFromMagnet).normalized * force;
            _currentVectorToMouse = (_input - Camera.main.WorldToScreenPoint(transform.position)).normalized;

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

        if (_input != Vector3.zero)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawSphere(Camera.main.ScreenToWorldPoint(_input), 2f);
        }
    }
}
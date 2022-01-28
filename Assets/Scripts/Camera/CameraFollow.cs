using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform[] _targets = null;

    [SerializeField] private float _smoothSpeed = 0.125f;
    [SerializeField] private float _screenshakeDistance = .2f;

    [SerializeField] private Vector3 _offset = Vector3.zero;

    private Vector3 _targetPosition = Vector3.zero;

    private void FixedUpdate()
    {
        _targetPosition = CalculateMidPoint();

        Debug.Log(_targetPosition);

        Vector3 desiredPosition = _targetPosition + _offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed * Time.fixedDeltaTime);
        transform.position = smoothedPosition;
    }

    private Vector3 CalculateMidPoint()
    {
        Vector3 pos = Vector3.zero;

        for (int i = 0; i < _targets.Length; i++)
        {
            pos += _targets[i].position;
        }

        return pos /= _targets.Length;
    }

    public void ScreenShake()
    {
        StopCoroutine(Shake());
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        for (int i = 0; i < 4; i++)
        {
            transform.position += new Vector3(
                (float)Random.Range(-_screenshakeDistance, _screenshakeDistance),
                (float)Random.Range(-_screenshakeDistance, _screenshakeDistance), 0);

            yield return new WaitForSeconds(.14f);
        }
    }
}

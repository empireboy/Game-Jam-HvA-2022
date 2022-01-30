using UnityEngine;

public class PlayerEndlessFall : MonoBehaviour
{
    public float yPosition = 20;
    public float rotationSpeed = 0.01f;

    private void Update()
    {
        if (transform.position.y <= yPosition)
        {
            transform.position = new Vector3(transform.position.x, -yPosition, transform.position.z);
        }

        transform.Rotate(new Vector3(0, 0, rotationSpeed));
    }
}
using UnityEngine;

public class MagnetMovement : MonoBehaviour
{
    public float rotationOffset;

    public void Snap(Vector3 position, float angle, float radius)
    {
        Vector2 offset = (Vector2)(Quaternion.Euler(0, 0, angle) * Vector2.right) * radius;

        transform.position = new Vector2(position.x, position.y) + offset;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + rotationOffset));
    }
}
using UnityEngine;

public class MagnetMovement : MonoBehaviour
{
    public float rotationOffset;

    private void Update()
    {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(GameObject.Find("Player Test").transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        Snap(GameObject.Find("Player Test").transform.position, angle, 1f);
    }

    public void Snap(Vector3 position, float angle, float radius)
    {
        Vector2 offset = (Vector2)(Quaternion.Euler(0, 0, angle) * Vector2.right) * radius;

        transform.position = new Vector2(position.x, position.y) + offset;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + rotationOffset));
    }
}
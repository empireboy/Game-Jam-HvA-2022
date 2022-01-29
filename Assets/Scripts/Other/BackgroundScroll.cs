using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] private GameObject[] chunks = new GameObject[0];
    [SerializeField] private GameObject[] points = new GameObject[0];

    [SerializeField] private float scrollSpeed = 10;

    private void Update()
    {
        for (int i = 0; i < chunks.Length; i++)
        {
            if (chunks[i].transform.position.x <= points[0].transform.position.x)
                chunks[i].transform.position = new Vector2(points[1].transform.position.x, chunks[i].transform.position.y);

            chunks[i].transform.position = new Vector2(chunks[i].transform.position.x + Time.deltaTime * -scrollSpeed, chunks[i].transform.position.y);
        }
    }
}

using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private Vector2 screenBoundaries;
    private float objectHeight;
    private float xFrom = -18.5f;
    private float xTo = 15f;

    void Start()
    {
        screenBoundaries = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectHeight = transform.GetComponent<CapsuleCollider2D>().size.y / 2;
    }

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, xFrom, xTo);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBoundaries.y * -1 + objectHeight, screenBoundaries.y - objectHeight);
        transform.position = viewPos;
    }
}
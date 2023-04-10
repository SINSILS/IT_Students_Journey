using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private Vector2 screenBoundaries;
    private float objectWidth;
    private float objectHeight;

    void Start()
    {
        screenBoundaries = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<CapsuleCollider2D>().size.x / 2;
        objectHeight = transform.GetComponent<CapsuleCollider2D>().size.y / 2;
    }

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBoundaries.x * -1 + objectWidth + 3.5f, screenBoundaries.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBoundaries.y * -1 + objectHeight, screenBoundaries.y - objectHeight);
        transform.position = viewPos;
    }
}
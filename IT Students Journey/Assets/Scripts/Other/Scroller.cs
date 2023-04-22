using UnityEngine;

public class Scroller : MonoBehaviour
{
    public SpriteRenderer _spriteRenderer;
    public float _x, _y;

    void Update()
    {
        _spriteRenderer.material.mainTextureOffset += new Vector2(_x, _y) * Time.deltaTime;
    }
}

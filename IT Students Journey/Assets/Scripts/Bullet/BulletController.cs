using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;
    public int bulletDirection = 1;
    public int damage = 5;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        move();
        outOfScreen();
        rotate();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    void outOfScreen()
    {
        if (transform.position.x <= -23 || transform.position.x >= 23)
        {
            Destroy(gameObject);
        }
    }

    private void rotate()
    {
        transform.Rotate(0, 0, -2);
    }

    void move()
    {
        if (bulletDirection == 1)
            transform.position += Vector3.right * speed * Time.deltaTime;
        else
            transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float bulletSpeed = 10f;
    private int bulletDirection = 1;
    private int bulletDamage = 5;
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
        AudioHelper.instance.PlayEnemyHit();
        collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent);
        if (!enemyComponent.isDead)
        {
            Destroy(gameObject);
        }
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
            transform.position += Vector3.right * bulletSpeed * Time.deltaTime;
        else
            transform.position += Vector3.left * bulletSpeed * Time.deltaTime;
    }

    public void setDirection(int direction)
    {
        bulletDirection = direction;
    }

    public int getDirection()
    {
        return bulletDirection;
    }

    public int getDamage()
    {
        return bulletDamage;
    }

    public void setDamage(int damage)
    {
        bulletDamage = damage;
    }
}
using ClearSky;
using UnityEngine;

public class projectileController : MonoBehaviour
{
    private float speed = 10f;
    private int damage;
    private GameObject player;
    private Vector2 direction;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        direction = (player.transform.position - transform.position).normalized;
        direction.y += 0.05f;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        outOfScreen();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Deal damage to player
        if (collision.gameObject.CompareTag("Player"))
        {
            StudentController student = GameObject.FindWithTag("Player").GetComponent<StudentController>();
            student.takeDamage(damage);
        }
        // Destroy the projectile on collision with any object
        Destroy(gameObject);
    }

    public void setDamage(int dmg)
    {
        damage = dmg;
    }
    void outOfScreen()
    {
        if (transform.position.x < -20 || transform.position.x > 23 || transform.position.y < -10 || transform.position.y > 11)
        {
            Destroy(gameObject);
        }
    }
}
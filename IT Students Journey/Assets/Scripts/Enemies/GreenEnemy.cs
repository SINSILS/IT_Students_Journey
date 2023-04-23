using ClearSky;
using UnityEngine;

public class GreenEnemy : Enemy
{
    private Rigidbody2D rb;
    //Green enemy stats
    Stats stats = new Stats();
    int mass;
    int damage;
    public float speed = 3f;
    public int value;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        setFirePosition();
    }

    // Update is called once per frame
    void Update()
    {
        titlePositionUpdate();
        fireProjectile();
        outOfMap();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        anim.SetBool("isJump", false);
    }

    public void Knockback(int direction, int damage)
    {
        rb.mass = mass;
        // Calculate the knockback force based on the enemy's mass and damage
        float knockbackForce = damage * 0.5f + rb.mass * 0.1f;

        // Apply the knockback force in the specified direction
        Vector3 knockbackVector = new Vector3(2.5f * direction, 0.1f, 0f) * knockbackForce;
        rb.AddForce(knockbackVector, ForceMode2D.Impulse);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!isDead)
        {
            if (collision.gameObject.tag == "Platform")
            {
                canMove = false;
                anim.SetBool("isJump", false);
            }
            else if (collision.gameObject.tag == "MainBottomPlatform")
            {
                canMove = true;
                anim.SetBool("isJump", true);
            }
            else
                anim.SetTrigger("isIdle");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) // Check if the enemy is dead
        {
            return; // If so, don't do anything
        }

        if (collision.gameObject.TryGetComponent<BulletController>(out BulletController bulletComponent))
        {
            Knockback(bulletComponent.getDirection(), bulletComponent.getDamage());
            anim.Play("Green Hurt - Animation");
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            if (!isDead) // Check if the enemy is alive
            {
                StudentController student = GameObject.FindWithTag("Player").GetComponent<StudentController>();
                student.takeDamage(damage);
            }
        }
    }

    public void outOfMap()
    {
        if (transform.position.y <= -10f && !isDead)
        {
            isDead = true; // Mark the enemy as dead
            gameObject.layer = 7;
            anim.SetTrigger("isDead");
            StudentController student = GameObject.FindWithTag("Player").GetComponent<StudentController>();
            student.addCoins(value);
        }
    }

    public override void setRandomStats(int minLevel, int maxLevel)
    {
        int random = Random.Range(minLevel, maxLevel);
        int random2;
        if (random == 4 || random == 7)
        {
            random2 = 0;
        }
        else if (random == 5)
        {
            random2 = Random.Range(0, 2);
        }
        else if (random == 1)
        {
            random2 = Random.Range(0, 4);
        }
        else if (random == 0)
        {
            random2 = Random.Range(0, 5);
        }
        else
        {
            random2 = Random.Range(0, 3);
        }
        title.text = stats.title[random][random2];
        mass = stats.mass[random];
        damage = stats.damage[random];
        value = stats.value[random];
    }

    public void fireProjectile()
    {
        if (!isDead && !canMove && canFire && transform.position.x < firePosition)
        {
            var newProjectile = GameObject.Instantiate(projectile, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            GameObject projectileParent = GameObject.Find("EnemyProjectiles");
            newProjectile.transform.SetParent(projectileParent.transform, false);
            projectileController projectileComponent = newProjectile.GetComponent<projectileController>();
            projectileComponent.setDamage(damage);
            canFire = false;
        }
    }
    private class Stats
    {
        //Will be updated when player reaches points 1000 -> 3, 2000 -> 4 and etc...
        public string[][] title = new string[8][]{ new string[5]{ "x = 5", "x = \"name\"", "x = true", "x = 3.14", "x >= y" },
                                        new string[4]{ "For", "While", "Break", "Continue"},
                                        new string[3]{ "x = [1, 2, 3]", "x.append(4)", "x[0] = 5"},
                                        new string[3]{ "file.read( )", "file.write( )", "file.close( )"},
                                        new string[1]{ "OPP"},
                                        new string[2]{ "Try", "Except"},
                                        new string[3]{ "NumPy", "Pandas", "Matplotlib"},
                                        new string[1]{ "Multithreading"},
    };
        public int[] mass = { 2, 4, 6, 8, 10, 12, 14, 16 };
        public int[] damage = { 5, 10, 15, 20, 25, 30, 35, 40 };
        public int[] value = { 1, 2, 3, 4, 5, 6, 7, 8 };
    }
}

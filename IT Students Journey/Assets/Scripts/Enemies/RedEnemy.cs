using ClearSky;
using UnityEngine;

public class RedEnemy : Enemy
{
    //Red enemy stats
    Stats stats = new Stats();
    int hp;
    int damage;
    public float speed;
    public int value;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        setFirePosition();
    }

    // Update is called once per frame
    void Update()
    {
        titlePositionUpdate();
        fireProjectile();
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            Move();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        anim.SetBool("isJump", false);
    }

    public void TakeDamage(int damageAmount)
    {
        hp -= damageAmount;
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
        if (collision.gameObject.CompareTag("Player"))
        {
            StudentController student = GameObject.FindWithTag("Player").GetComponent<StudentController>();
            Vector2 contactPoint = collision.contacts[0].point;
            if (contactPoint.y > transform.position.y && !isDead) // Check if the player is above the enemy
            {
                TakeDamage(student.getPower()); // Receive damage from player
                student.Bounce();
                if (hp > 0)
                {
                    anim.Play("Red Hurt - Animation");
                }
                else
                {
                    PlayerConfig.instance.playerData.levelScores[LanguageEnum.JavaScript].mobsKilled++;
                    isDead = true; // Mark the enemy as dead
                    gameObject.layer = 7;
                    anim.SetTrigger("isDead");
                    student.addCoins(value);
                }
            }
            else if (!isDead) // Check if the enemy is alive
            {
                student.takeDamage(damage);
            }
        }
    }

    public override void setRandomStats(int minLevel, int maxLevel)
    {

        int random = Random.Range(minLevel, maxLevel);
        int random2;
        if (random == 0)
        {
            random2 = Random.Range(0, 4);
        }
        else if (random == 2 || random == 4 || random == 5 || random == 7)
        {
            random2 = 0;
        }
        else if (random == 3 || random == 6)
        {
            random2 = Random.Range(0, 2);
        }
        else
        {
            random2 = Random.Range(0, 3);
        }
        title.text = stats.title[random][random2];
        hp = stats.hp[random];
        damage = stats.damage[random];
        speed = stats.speed[random];
        value = stats.value[random];
    }

    public override void setFirePosition()
    {
        firePosition = Random.Range(-17f, 21f);
    }

    public void fireProjectile()
    {
        if (!isDead && canFire && transform.position.x < firePosition)
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
        public string[][] title = new string[8][]{ new string[4]{ "let x = 5", "var x = \"name\"", "let x = true", "var x = 3.14" },
                                        new string[3]{ "Control flow", "While", "For"},
                                        new string[1]{ "Functions"},
                                        new string[2]{ "Arrays", "Objects",},
                                        new string[1]{ "DOM"},
                                        new string[1]{ "Events"},
                                        new string[2]{ "AJAX", "API"},
                                        new string[1]{ "ES6"}
    };
        public int[] hp = { 10, 20, 30, 40, 50, 60, 70, 80 };
        public int[] damage = { 5, 10, 15, 20, 25, 30, 35, 40 };
        public float[] speed = { 3f, 3.4f, 3.8f, 4.2f, 4.6f, 5f, 5.4f, 5.8f };
        public int[] value = { 1, 2, 3, 4, 5, 6, 7, 8 };
    }
}

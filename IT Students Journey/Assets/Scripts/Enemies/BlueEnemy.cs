using ClearSky;
using UnityEngine;

public class BlueEnemy : Enemy
{
    //Blue enemy stats
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

        if (collision.gameObject.TryGetComponent<BulletController>(out BulletController bulletComponent))
        {
            TakeDamage(bulletComponent.getDamage());
            if (hp > 0)
            {
                anim.Play("Blue Hurt - Animation");
            }
            else
            {
                PlayerConfig.instance.playerData.levelScores[LanguageEnum.CSharp].mobsKilled++;
                isDead = true; // Mark the enemy as dead
                AudioHelper.instance.PlayEnemyDeath();
                gameObject.layer = 7;
                anim.SetTrigger("isDead");
                StudentController student = GameObject.FindWithTag("Player").GetComponent<StudentController>();
                student.addCoins(value);
            }
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

    public override void setRandomStats(int minLevel, int maxLevel)
    {

        int random = Random.Range(minLevel, maxLevel);
        int random2;
        if (random <= 4)
        {
            random2 = Random.Range(0, 5);
        }
        else if (random <= 6)
        {
            random2 = 0;
        }
        else
        {
            random2 = Random.Range(0, 4);
        }
        title.text = stats.title[random][random2];
        hp = stats.hp[random];
        damage = stats.damage[random];
        speed = stats.speed[random];
        value = stats.value[random];
    }

    //Might need to update with fireRate instead of 1 projectile per enemy
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
        public string[][] title = new string[8][]{ new string[5]{ "int x;", "string x;", "bool x;", "double x;", "float x;" },
                                        new string[5]{ "int[ ] x;", "string[ ] x;", "bool[ ] x;", "double[ ] x;", "float[ ] x;"},
                                        new string[5]{ "List<int> x;", "List<string> x;", "List<bool> x;", "List<double> x;", "List<float> x;"},
                                        new string[5]{ "int[ ][ ] x;", "string[ ][ ] x;", "bool[ ][ ] x;" ,"double[ ][ ] x;", "float[ ][ ] x;",},
                                        new string[5]{ "Stack<T> x;", "Queue<T> x", "LinkedList<T> x", "Dictionary<Tkey, TValue> x", "HashSet<T> x"},
                                        new string[1]{ "LINQ"},
                                        new string[1]{ "ASP.NET"},
                                        new string[4]{ "Thread.Start()", "Thread.Join()", "Thread.Sleep()", "Thread.Abort()"}
    };
        public int[] hp = { 10, 20, 30, 40, 50, 60, 70, 80 };
        public int[] damage = { 5, 10, 15, 20, 25, 30, 35, 40 };
        public float[] speed = { 3f, 3.4f, 3.8f, 4.2f, 4.6f, 5f, 5.4f, 5.8f };
        public int[] value = { 1, 2, 3, 4, 5, 6, 7, 8 };
    }
}

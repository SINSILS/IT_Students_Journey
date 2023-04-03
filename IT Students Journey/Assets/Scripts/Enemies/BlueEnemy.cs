using TMPro;
using UnityEngine;
public class BlueEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    //Stats
    Stats stats = new Stats();
    public TMP_Text title;
    int hp;
    int damage;
    public float speed;

    bool canMove = false;
    public bool isDead = false;
    public int platformIndex { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        setRandomStats();
    }

    // Update is called once per frame
    void Update()
    {
        titlePositionUpdate();
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

    public void TakeDamage(float damageAmount)
    {
        Debug.Log("I was touched!!!");
    }

    void Move()
    {
        if (!isDead)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
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
        if (collision.gameObject.TryGetComponent<BulletController>(out BulletController bulletComponent))
        {
            hp = hp - bulletComponent.damage;
            if (hp > 0)
            {
                anim.Play("Blue Hurt - Animation");
                if (bulletComponent.bulletDirection == 1)
                {
                    rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
                }
                else
                {
                    rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
                }
            }
            else
            {
                anim.SetTrigger("isDead");
            }
        }
    }

    public void setIsHurtFalse()
    {
        anim.SetTrigger("isIdle");
    }

    public void setIsDeadTrue()
    {
        isDead = true;
    }

    void titlePositionUpdate()
    {
        title.transform.position = new Vector2(transform.position.x, transform.position.y + (float)0.5);
    }

    void setRandomStats()
    {
        int random = Random.Range(0, stats.randomByLevel);
        int random2 = Random.Range(0, 5);
        title.text = stats.title[random][random2];
        hp = stats.hp[random];
        damage = stats.damage[random];
        speed = stats.speed[random];
    }
}

class Stats
{
    //Will be updated when player reaches points 1000 -> 3, 2000 -> 4 and etc...
    public int randomByLevel = 2;
    public string[][] title = new string[8][]{ new string[5]{ "int x;", "string x;", "bool x;", "double x;", "float x;" },
                                        new string[5]{ "int[ ] x;", "string[ ] x;", "bool[ ] x;", "double[ ] x;", "float[ ] x;"},
                                        new string[5]{ "List<int> x;", "List<string> x;", "List<bool> x;", "List<double> x;", "List<float> x;"},
                                        new string[]{ },//int [][] x
                                        new string[]{ },//stack - queue - deck?
                                        new string[]{ },
                                        new string[]{ },
                                        new string[]{ } //multithreading
    };
    public int[] hp = { 10, 20, 30, 40, 50, 60, 70, 80 };
    public int[] damage = { 1, 2, 3, 4, 5, 6, 7, 8 };
    public float[] speed = { 3f, 3.2f, 3.4f, 3.6f, 3.8f, 4f, 4.2f, 4.4f };
}

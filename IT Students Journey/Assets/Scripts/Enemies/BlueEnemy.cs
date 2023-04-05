using ClearSky;
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
    public int value;

    //Additional parameters
    bool canMove = false;
    public bool isDead = false;
    public int platformIndex { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
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
            }
            else
            {
                anim.SetTrigger("isDead");
                StudentController student = GameObject.FindWithTag("Player").GetComponent<StudentController>();
                student.coins += value;
            }
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            StudentController student = GameObject.FindWithTag("Player").GetComponent<StudentController>();
            student.takeDamage(damage);
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

    public void setRandomStats(int level)
    {
        int random = Random.Range(0, level);
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
}

class Stats
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
    //public float[] speed = { 3f, 3.2f, 3.4f, 3.6f, 3.8f, 4f, 4.2f, 4.4f };
    public float[] speed = { 3f, 3.4f, 3.8f, 4.2f, 4.6f, 5f, 5.4f, 5.8f };
    public int[] value = { 1, 2, 3, 4, 5, 6, 7, 8 };
}

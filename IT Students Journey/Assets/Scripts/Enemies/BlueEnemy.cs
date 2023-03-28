using TMPro;
using UnityEngine;
public class BlueEnemy : MonoBehaviour
{
    private Animator anim;
    //Stats
    Stats stats = new Stats();
    public float speed = 3f;
    bool canMove = false;
    public int platformIndex { get; set; }

    public TMP_Text title;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void OnCollisionStay2D(Collision2D collision)
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

    void titlePositionUpdate()
    {
        title.transform.position = new Vector2(transform.position.x, transform.position.y + (float)0.5);
    }

    void setRandomStats()
    {
        int random = Random.Range(0, stats.randomByLevel);
        int random2 = Random.Range(0, 5);
        title.text = stats.title[random][random2];
    }
}

class Stats
{
    //Will be updated when player reaches points 1000 -> 3, 2000 -> 4 and etc...
    public int randomByLevel = 2;
    public int[] hp = { 1, 2, 3, 4, 5, 6, 7, 8 };
    public int[] damage = { 1, 2, 3, 4, 5, 6, 7, 8 };
    public float[] speed = { 3f, 3.2f, 3.4f, 3.6f, 3.8f, 4f, 4.2f, 4.4f };
    public string[][] title = new string[8][]{ new string[5]{ "int x;", "string x;", "bool x;", "double x;", "float x;" },
                                        new string[5]{ "int[ ] x;", "string[ ] x;", "bool[ ] x;", "double[ ] x;", "float[ ] x;"},
                                        new string[5]{ "List<int> x;", "List<string> x;", "List<bool> x;", "List<double> x;", "List<float> x;"},
                                        new string[]{ },//int [][] x
                                        new string[]{ },//stack - queue - deck?
                                        new string[]{ },
                                        new string[]{ },
                                        new string[]{ } //multithreading
    };
}

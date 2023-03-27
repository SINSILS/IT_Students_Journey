using TMPro;
using UnityEngine;

public class BlueEnemy : MonoBehaviour
{
    private Animator anim;
    //private Rigidbody2D rb;
    public float speed = 3f;
    bool canMove = false;
    public int platformIndex { get; set; }

    public TMP_Text title;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        titlePosition();
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

    void titlePosition()
    {
        title.transform.position = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y, transform.position.z));
        title.transform.position = new Vector3(title.transform.position.x, title.transform.position.y + 1, title.transform.position.z);
    }
}

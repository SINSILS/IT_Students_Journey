using ClearSky;
using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private new Collider2D collider;
    private bool studentOnPlatform;
    private Rigidbody2D rb;
    private float speed = 3f;
    public bool isTaken { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (studentOnPlatform && Input.GetAxisRaw("Vertical") < 0)
        {
            collider.enabled = false;
            StartCoroutine(enableCollider());
        }

    }

    // FixedUpdate is called once per physics update
    void FixedUpdate()
    {
        // Move the platform to the left
        move();
    }

    private IEnumerator enableCollider()
    {
        yield return new WaitForSeconds(0.5f);
        collider.enabled = true;
    }

    private void setStudentOnPlatform(Collision2D other, bool value)
    {
        var student = other.gameObject.GetComponent<StudentController>();
        if (student != null)
        {
            studentOnPlatform = value;
        }
    }

    void move()
    {
        Vector2 move = rb.position + Vector2.left * speed * Time.fixedDeltaTime;
        rb.MovePosition(move);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        setStudentOnPlatform(other, true);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        setStudentOnPlatform(other, false);
    }
}

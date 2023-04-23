using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public projectileController projectile;
    public Animator anim;
    public TMP_Text title;

    //Additional parameters
    public bool canMove = false;
    public bool canFire = true;
    public float firePosition;
    public bool isDead = false;
    public int platformIndex { get; set; }

    public void Move()
    {
        if (!isDead)
        {
            transform.position += Vector3.left * 3 * Time.deltaTime;
        }
    }
    public void titlePositionUpdate()
    {
        title.transform.position = new Vector2(transform.position.x, transform.position.y + (float)0.5);
    }

    public virtual void setRandomStats(int minLevel, int maxLevel)
    {
        //Each enemy sets stats diferently
    }

    public virtual void setFirePosition()
    {
        if (!canMove)
        {
            firePosition = Random.Range(-17f, 21f);
        }
    }
    public void setIsHurtFalse()
    {
        anim.SetTrigger("isIdle");
    }
}


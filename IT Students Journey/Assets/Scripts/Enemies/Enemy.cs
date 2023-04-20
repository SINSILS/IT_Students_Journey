using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public projectileController projectile;

    public TMP_Text title;

    //Additional parameters
    public bool canMove = false;
    public bool canFire = true;
    public float firePosition;
    public bool isDead = false;
    public int platformIndex { get; set; }

    public virtual void TakeDamage(int damageAmount)
    {
    }

    public virtual void Move()
    {
    }
    public virtual void setIsHurtFalse()
    {
    }
    public virtual void titlePositionUpdate()
    {
    }

    public virtual void setRandomStats(int minLevel, int maxLevel)
    {
    }

    public virtual void setFirePosition()
    {
    }

    public virtual void fireProjectile()
    {
    }
}


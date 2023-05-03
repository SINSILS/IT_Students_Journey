using TMPro;
using UnityEngine;

namespace ClearSky
{
    public class StudentController : MonoBehaviour
    {
        //1 - C#, 3 - Pyhton, 4 - JS
        private int studyingLanguage;

        //Student stats
        private int hp = 50;
        private int coins = 0;
        private float jumpPower = 25f;

        //Upgradable stats
        private int maxHP = 50;
        private float speed = 10f;
        private int power = 5;
        private double fireRate = 1.0;

        [SerializeField] private TMP_Text hpLabel;
        [SerializeField] private TMP_Text coinsLabel;
        private Rigidbody2D rb;
        private Animator anim;
        private int direction = 1;
        bool isJumping = false;
        private bool alive = true;
        bool _gotHurt = false;

        //Bullet prefab
        [SerializeField] private GameObject bulletPrefab;
        private double lastShot = 0.0;

        //Parent GameObjects
        private GameObject bulletParent;


        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            bulletParent = new GameObject("Bullets");
            InvokeRepeating("regenerateHP", 0.1f, 5.0f);
        }

        private void Update()
        {
            updateHPLabel();
            if (alive)
            {
                jump();
                run();
                updateCoinsLabel();
                if (studyingLanguage != 4)
                {
                    attack();
                }
                if (studyingLanguage == 3)
                {
                    outOfBoundaries();
                }
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            anim.SetBool("isJump", false);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (alive)
            {
                if (collision.gameObject.TryGetComponent<ProjectileController>(out ProjectileController projectile))
                {
                    hurt();
                }
                if (collision.gameObject.tag == "MainBottomPlatform" || (collision.gameObject.tag == "Platform" && studyingLanguage == 3))
                {
                    anim.SetBool("isJump", false);
                    isJumping = false;
                }
            }
        }

        public void setSceneIndex(int index)
        {
            studyingLanguage = index;
        }

        public int getSceneIndex()
        {
            return studyingLanguage;
        }

        void run()
        {

            Vector3 moveVelocity = Vector3.zero;
            anim.SetBool("isRun", false);


            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                direction = -1;
                moveVelocity = Vector3.left;

                transform.localScale = new Vector3(direction, 1, 1);
                if (!anim.GetBool("isJump"))
                    anim.SetBool("isRun", true);

            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                direction = 1;
                moveVelocity = Vector3.right;

                transform.localScale = new Vector3(direction, 1, 1);
                if (!anim.GetBool("isJump"))
                    anim.SetBool("isRun", true);

            }
            transform.position += moveVelocity * speed * Time.deltaTime;
        }
        void jump()
        {
            if ((Input.GetKeyDown(KeyCode.W) || Input.GetAxisRaw("Vertical") > 0) && !anim.GetBool("isJump"))
            {
                isJumping = true;
                anim.SetBool("isJump", true);
            }
            if (!isJumping)
            {
                return;
            }

            rb.velocity = Vector2.zero;

            Vector2 jumpVelocity = new Vector2(0, jumpPower);
            rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

            isJumping = false;
        }

        public void bounce()
        {
            if (!anim.GetBool("isJump"))
            {
                isJumping = true;
                anim.SetBool("isJump", true);
            }
            rb.velocity = Vector2.zero;
            Vector2 jumpVelocity = new Vector2(0, jumpPower);
            rb.AddForce(jumpVelocity, ForceMode2D.Impulse);
            isJumping = false;
        }

        void attack()
        {
            if (Input.GetKeyDown(KeyCode.Space) && Time.time > fireRate + lastShot)
            {
                AudioHelper.instance.PlayThrowSound();
                anim.SetTrigger("attack");
                float x = transform.position.x + 1.5f;
                if (direction == -1)
                {
                    x = transform.position.x - 1.5f;
                }
                float y = transform.position.y + 1.5f;
                // Create a new bullet
                var bullet = GameObject.Instantiate(bulletPrefab, new Vector2(x, y), Quaternion.identity);
                var bulletController = bullet.GetComponent<BulletController>();
                bulletController.setDirection(direction);
                bulletController.setDamage(power);
                bullet.transform.SetParent(bulletParent.transform, false);
                // Save last shot time
                lastShot = Time.time;
            }
        }

        void outOfBoundaries()
        {
            if (transform.position.y <= -9.2f)
            {
                hp = 0;
                die();
            }
        }

        public bool gotHurt()
        {
            return _gotHurt;
        }

        public void takeDamage(int damage)
        {
            if (alive)
            {
                _gotHurt = true;
                hurt();
                hp -= damage;
                if (hp <= 0)
                {
                    die();
                }
            }
        }
        void hurt()
        {
            if (anim != null && rb != null)
            {
                anim.SetTrigger("hurt");
                if (direction == 1)
                    rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
                else
                    rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
            }
        }

        void die()
        {
            if (anim != null)
            {
                anim.SetTrigger("die");
            }
            alive = false;
        }

        void regenerateHP()
        {
            if (alive && hp < maxHP)
            {
                hp++;
            }
        }

        void updateHPLabel()
        {
            if (hp < 0)
            {
                hpLabel.text = "HP : 0";
            }
            else
            {
                hpLabel.text = "HP : " + hp;
            }
        }

        void updateCoinsLabel()
        {
            coinsLabel.text = "Coins : " + coins;
        }

        public int getMaxHP()
        {
            return maxHP;
        }

        public float getSpeed()
        {
            return speed;
        }

        public int getPower()
        {
            return power;
        }

        public double getFireRate()
        {
            return fireRate;
        }

        public int getMissingHP()
        {
            return maxHP - hp;
        }

        public int getCurrentHP()
        {
            return hp;
        }

        public int getCoins()
        {
            return coins;
        }

        public void addCoins(int amount)
        {
            coins += amount;
        }

        public void payCoins(int amount)
        {
            if (coins <= 10)
            {
                coins = 0;
            }
            else
            {
                coins -= amount;
            }
        }

        public void updateMaxHP(int x)
        {
            if (hp >= 60 && x < 0)
            {
                maxHP += x;
                hp += x;
            }
            else if (hp >= 50 && x < 0)
            {
                hp = 50;
                maxHP += x;
            }
            else
            {
                maxHP += x;
            }
        }

        public void updateSpeed(float x)
        {
            speed += x;
        }

        public void updatePower(int x)
        {
            power += x;
        }

        public void updateFireRate(double x)
        {
            fireRate -= x;
        }

        public void resetHealth()
        {
            hp = maxHP;
        }

        public bool isAlive()
        {
            return alive;
        }
    }
}
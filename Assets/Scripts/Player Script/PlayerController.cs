using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    public float min_Y, max_Y;
    public GameObject[] Bullet;
    public GameManager gameManager;

    [SerializeField]
    private Transform attack_Point;

    public float attack_Timer = 0.35f;
    private float current_Attack_Timer;
    private bool canAttack;
    private int upgradeCount;
    private int currProjectileLevel;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        current_Attack_Timer = attack_Timer;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        currProjectileLevel = 0;
        upgradeCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Attack();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PBE"))
        {
            // decrease health
            TakeDamage(5);
        }
        if(collision.CompareTag("Asteroids"))
        {
            TakeDamage(8);
        }

        if (collision.CompareTag("Loots"))
        {
            if(currentHealth < 100)
            {
                if(currentHealth + 5 > 100)
                {
                    TakeDamage(currentHealth - 100);
                }
                else
                {
                    //Increase health
                    TakeDamage(-5);
                }
            }
        }
        if (collision.CompareTag("Upgrades"))
        {
            //Do upgrade
            upgradeCount++;
            if (upgradeCount >= 8)
                currProjectileLevel = 1;
            if (upgradeCount >= 15)
                currProjectileLevel = 2;
        }
        if (currentHealth <= 0)
        {
            gameManager.endGame();
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    void MovePlayer() {

        if(Input.GetAxisRaw("Vertical") > 0f) {

            Vector3 temp  = transform.position;
            temp.y += speed * Time.deltaTime;

        // Setting the limit for upper bounds movement
            if(temp.y > max_Y) {
                temp.y = max_Y;

            }

            transform.position = temp;

        } else if( Input.GetAxisRaw("Vertical") < 0f) {
            
            Vector3 temp  = transform.position;
            temp.y -= speed * Time.deltaTime;

        // Setting the lower for upper bounds movement
            if(temp.y < min_Y){
                temp.y = min_Y;

            }

            transform.position = temp;

        }
    }

    void Attack () {
        attack_Timer += Time.deltaTime;

        if(attack_Timer - current_Attack_Timer > 1 / (currProjectileLevel + 1))
        {
            if (GeneralData.onOtherTasks == false)
            {
                canAttack = true;
            }
        }

        if(Input.GetMouseButtonDown(0)) {
            if(canAttack){

                canAttack = false;
                attack_Timer = 0f;
                if(currProjectileLevel > Bullet.Length)
                {
                    currProjectileLevel = Bullet.Length - 1;
                }
                Instantiate(Bullet[currProjectileLevel], attack_Point.position, Quaternion.identity);

                //play sfx
            }
        }
    }

    

}

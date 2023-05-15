 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScrpt : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.5f;
    public float deactivate_Timer = 10f;

    public GameObject Bullet;
    public GameObject destruction;
    public GameObject[] loots;

    [SerializeField]
    private Transform attack_Point;


    public float attack_Interval = 3f;
    public GameManager gameManager;
    private float current_Attack_Timer;
    private bool canAttack;

    float sinCenterY;
    public float amplitude = 2f;
    public float frequency = 0.5f;
    public bool inverted;
    private float rate;

    void Start()
    {
        float randomType = Random.value;
        sinCenterY = transform.position.y;
        inverted = false;
        rate = Random.value;

        //Alter random once more time for frequency
        randomType = Random.value;
        if (randomType < 0.4)
        {
            frequency = 2f;
        }
        else if (randomType < 0.7 && randomType >= 0.4)
        {
            frequency = 1f;
        }
        else
        {
            frequency = 0.5f;
        }

        //Alter random once more time for speed
        randomType = Random.value;
        if (randomType < 0.2)
        {
            if(randomType < 0.07)
            {
                attack_Interval = 0.5f;
            }
            speed = 1f;
        }
        else if(isInrange(randomType, 0.2f, 0.5f))
        {
            speed = 0.8f;
        }
        else
        {
            speed = 0.5f;
        }
        InvokeRepeating("Attack", attack_Interval, attack_Interval);
    }

    // Update is called once per frame
    void Update()
    {
        if (GeneralData.onOtherTasks == false)
        {
            if (rate < 0.5)
            {
                MoveEnemyInSineWave();
            }
            else
            {
                MoveEnemy();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PB"))
        {
            Instantiate(destruction, gameObject.transform.position, Quaternion.identity);
            lootDrop();
            Destroy(gameObject);
        }
        
    }
    void MoveEnemyInSineWave()
    {
        MoveEnemy();
        Vector3 pos = gameObject.transform.position;
        float sin = Mathf.Sin(pos.x*frequency) * amplitude;
        if(inverted)
        {
            sin *= -1;
        }
        pos.y = sinCenterY + sin;
        transform.position = pos;
    }
    void MoveEnemy(){
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void lootDrop()
    {
        int lootent = Random.Range(0, loots.Length);
        for(int i = 0; i < lootent; i++)
        {
            if(loots[i] != null)
            {
                Instantiate(loots[Random.Range(0, loots.Length)], gameObject.transform.position, Quaternion.identity);
            }
        }
    }
    void Attack () {
        if(GeneralData.onOtherTasks == false)
        {
            if (!gameObject.activeSelf)
            {

                CancelInvoke("Attack");
            }
            Instantiate(Bullet, attack_Point.position, Quaternion.identity); 
        }

    }

    private bool isInrange(float u, float low, float high)
    {
        if (u >= low && u <= high)
            return true;
        return false;
    }
}

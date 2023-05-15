using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    private int health;
    void Start()
    {
        health = 100;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Enemy":
                health -= 10;
                break;
            case "Asteroids":
                health -= 20;
                break;
            case "PBE":
                health -= 5;
                break;
            default:
                break;
        }
        //if(collision.CompareTag("Enemy") || collision.CompareTag("PBE"))
        //{
        //    health--;
        //}

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

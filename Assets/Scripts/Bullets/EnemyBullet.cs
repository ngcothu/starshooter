using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5f;
    public float deactivate_Timer = 3.5f;

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GeneralData.onOtherTasks == false)
        {
            Move();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    void Move() {

        Vector3  temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;
        if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootScript : MonoBehaviour
{
    public float speed = 5f;
    public float deactivate_Timer = 3.5f;
    private float startTime;
    private bool isTimerStart;
    // Start is called before the first frame update
    void Start()
    {
        isTimerStart = false;
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
    void Move()
    {

        Vector3 temp = transform.position;
        if(!isTimerStart)
        {
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;
        }

        if (transform.position.x < -9.42)
        {
            if (!isTimerStart)
            {
                startTime = Time.time;
                isTimerStart = true;
            }
        }
        if(isTimerStart)
        {
            float elapsedTime = Time.time - startTime;
            if (elapsedTime > 4)
            {
                isTimerStart = false;
                Destroy(gameObject);
            }
        }
    }
}

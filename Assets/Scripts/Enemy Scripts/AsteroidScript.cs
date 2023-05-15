using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float speed = 0.5f;
    public float deactivate_Timer = 10f;

    public GameObject destruction;

    float sinCenterY;
    public float amplitude = 2f;
    public float frequency = 0.5f;
    public bool inverted;
    private float rate;

    // Start is called before the first frame update
    void Start()
    {
        float randomType = Random.value;
        sinCenterY = transform.position.y;
        inverted = false;

        //Set various speed and movement type of GameObject
        rate = Random.value;
        if(randomType < 0.5)
        {
            amplitude = 2.5f;
        }
        else if(randomType < 0.7 && randomType >= 0.5)
        {
            amplitude = 2f;
        }
        else
        {
            amplitude = 1.5f;
        }
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
            speed = 1.2f;
        }
        else if (randomType < 0.5 && randomType >= 0.2)
        {
            speed = 0.8f;
        }
        else
        {
            //This is the plane of z = x*y range is from 0-1
            if(rate * randomType > 0.4f)
            {
                //Speed is various
                speed = randomType;
            }
            else
                //Speed is predictable
                speed = 0.4f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GeneralData.onOtherTasks == false)
        {
            if (rate < 0.5)
            {
                MoveInSineWave();
            }
            else
            {
                Move();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PB"))
        {
            Instantiate(destruction, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    void MoveInSineWave()
    {
        Move();
        Vector3 pos = gameObject.transform.position;
        float sin = Mathf.Sin(pos.x * frequency) * amplitude;
        if (inverted)
        {
            sin *= -1;
        }
        pos.y = sinCenterY + sin;
        transform.position = pos;
    }
    void Move()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private bool isInrange(float u, float low, float high)
    {
        if (u > low && u < high)
            return true;
        return false;
    }
}

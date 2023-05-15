using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    public float deactivate_Timer = 3.5f;
    public ScoreText scoretext;
    //private Animation anim;

    // [SerializeField]
    // private GameObject enemy_explosion;

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Asteroids"))
        {

            FindObjectOfType<ScoreText>().increaseScore(1);
            Destroy(gameObject);

        }
    }

    void Move() {

        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
        if(temp.x > 15)
        {
            Destroy(gameObject);
        }
    }

    //void DeactivateGameObject()
    //{
    //    Destroy(gameObject);
    //}
}

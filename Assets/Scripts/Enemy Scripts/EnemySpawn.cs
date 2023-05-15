using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyShip;
    public GameObject[] asteroid;
    public GameManager gameManager;
    static private int enemyCnt = 0;
    static private int esCnt = 0;
    public float min_Y = -4.41f;
    public float max_Y = 4.41f;
    public float spawnIntervalMin = 1f;
    public float spawnIntervalMax = 3f;

    private float startTime;



    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        
        // Start spawning enemies at random intervals
        InvokeRepeating("SpawnEnemy", Random.Range(spawnIntervalMin, spawnIntervalMax), Random.Range(spawnIntervalMin, spawnIntervalMax));
        // Start spawning asteroids at random intervals
        InvokeRepeating("SpawnAsteroids", Random.Range(spawnIntervalMin, spawnIntervalMax + 4f), Random.Range(spawnIntervalMin, spawnIntervalMax + 1f));

    }

    // Update is called once per frame
    void Update()
    {
        float elapsedTime = Time.time - startTime;
        if (elapsedTime%60 == 1)
        {
            if (spawnIntervalMin < 3f && spawnIntervalMax < 5f)
            {
                spawnIntervalMin += 0.2f;
                spawnIntervalMax += 0.2f;
            }
        }
    }

    void SpawnAsteroids()
    {
        if (!gameManager.getGameState() && GeneralData.onOtherTasks == false)
        {
            if (GameObject.FindGameObjectsWithTag("Asteroids").Length < 10)
            {
                // Instantiate the enemy spaceship at the right edge of the screen
                GameObject enemy = Instantiate(asteroid[Random.Range(0, 3)], new Vector3(14f, Random.Range(min_Y, max_Y), 0f), Quaternion.Euler(0f, 0f, 90f));
            }
        }
    }

    void SpawnEnemy()
    {
        if (!gameManager.getGameState() && GeneralData.onOtherTasks == false)
        {
            // Generate a random Y position for the enemy spaceship
            float yPos = Random.Range(min_Y, max_Y);

            if (GameObject.FindGameObjectsWithTag("Enemy").Length < 10)
            {
                // Instantiate the enemy spaceship at the right edge of the screen
                GameObject enemy = Instantiate(enemyShip, new Vector3(14f, yPos, 0f), Quaternion.Euler(0f, 0f, 90f));
            }

        }
    }


}

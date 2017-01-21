using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] enemyList;
    private float spawnTimer;
    private float difficultyTimer;
    public float maxSpawnTime;
    public float minSpawnTime;
    public int maxPackSize;
    public int minPackSize;
    public int difficultyLevel;
    private int currentRotation;
    public float incrementDifficultyTime;

    // Use this for initialization
    void Start()
    {
        spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);
        difficultyTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        difficultyTimer += Time.deltaTime;

        if (spawnTimer <= 0)
        {
            for (int i = 0; i <= (int)Random.Range(minPackSize, maxPackSize); i++)
            {
                GameObject enemy = enemyList[(int)Random.Range(0, enemyList.Length)];
                Instantiate(enemy, new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y + 1, transform.position.z + Random.Range(-2, 2)), Quaternion.identity);
                spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);
            }
        }
    }

    void IncrementDifficulty()
    {
        difficultyLevel++;
        currentRotation++;

        if(difficultyLevel % 1 == 0)
        {
            maxPackSize++;
        }
        else
        {
            minPackSize++;
        }
    }
}

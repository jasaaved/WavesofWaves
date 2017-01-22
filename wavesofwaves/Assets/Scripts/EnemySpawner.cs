using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] enemyList;
    private float spawnTimer;
    private float difficultyTimer;
    private int spawnCount;
    public float maxSpawnTime;
    public float minSpawnTime;
    public int maxPackSize;
    public int minPackSize;
    public int difficultyLevel;
    private int currentRotation;
    public float incrementDifficultyTime;
    public bool isFinished;

    // Use this for initialization
    void Start()
    {
        spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);
        difficultyTimer = 0;
        spawnCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGameOver)
        {
            return;
        }

        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0 && spawnCount < Mathf.Round((GameManager.Instance.currentLevel * 1.5f)) && !isFinished)
        {
            for (int i = 0; i <= (int)Random.Range(minPackSize, maxPackSize); i++)
            {
                GameObject enemy = enemyList[(int)Random.Range(0, enemyList.Length)];
                Instantiate(enemy, new Vector3(transform.position.x + Random.Range(-1, 1), transform.position.y + 1, transform.position.z + Random.Range(-1, 1)), Quaternion.identity);
                spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);
            }
            spawnCount++;
        }
        else if(spawnCount >=  (GameManager.Instance.currentLevel * 1.5f))
        {
            isFinished = true;
        }
    }


    public void ResetSpawnCount()
    {
        spawnCount = 0;
        isFinished = false;
        spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);
    }
}

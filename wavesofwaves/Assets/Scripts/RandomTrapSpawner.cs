using UnityEngine;

public class RandomTrapSpawner : MonoBehaviour
{
    public bool generateAtStart;
    public float floorY;
    public Vector2 maxPoint;
    public Vector2 minPoint;
    public float playerRadius; //Saftey radius where traps will not spawn around the player
    public float trapRadius; //Saftey radius where traps will not spawn around other traps
    public int numTrapsStart; //Number of traps to spawn at the start
    public GameObject[] trapPrefabs;

    private Transform playerTrans;
    private Vector3[] spawnpoints; //Temporary storage for all trap spawn points
    private GameObject[] spawnedTrapsList = new GameObject[0];
	
	void Start ()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        if (generateAtStart)
        {
            SpawnTraps(numTrapsStart);
        }
	}
	
	void SpawnTraps (int numTraps)
    {
		if (spawnedTrapsList.Length != 0)
        {
            foreach (GameObject go in spawnedTrapsList)
            {
                Destroy(go);
            }
            spawnedTrapsList = new GameObject[0];
        }

        spawnedTrapsList = new GameObject[numTraps];
        spawnpoints = new Vector3[numTraps];

        for (int a = 0; a < spawnedTrapsList.Length; a++)
        {
            do
            {
                spawnpoints[a] = new Vector3(Random.Range (minPoint.x, maxPoint.x), floorY, Random.Range(minPoint.y, maxPoint.y));
            } while (Vector3.Distance(spawnpoints[a], playerTrans.position) < playerRadius);

            spawnedTrapsList[a] = Instantiate(trapPrefabs[Random.Range(0, trapPrefabs.Length)], spawnpoints[a], Quaternion.identity);
        }

        spawnpoints = new Vector3[0];
	}
}

using UnityEngine;

public class LightWave : MonoBehaviour
{
    public float confuseTime;

    private GameObject player;
    private Light glow;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        glow = GetComponentInParent<Light>();
        Destroy(this.gameObject.transform.root.gameObject, 0.5f);
        glow.intensity = 0;
    }

    private void Update()
    {
        glow.intensity += Time.deltaTime * 16;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            EnemyMovement enemy = other.GetComponent<EnemyMovement>();
            enemy.confused = true;
            enemy.ccTimer = confuseTime;
            enemy.randomDestination = enemy.RandomDestination();
        }
    }
}

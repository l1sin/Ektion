using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform pos;
    public float size;
    public GameObject prefab;

    public float SpawnPerMinute;
    public float SpawnTimer;
    public float SpawnTime;

    public ObjectPool EnemyPool;
    public LayerMask AllowedSpawn;

    public void Start()
    {
        SpawnTime = 60 / SpawnPerMinute;
        SpawnTimer = SpawnTime;
    }

    private void Update()
    {
        SpawnTimer -= Time.deltaTime;
        if (SpawnTimer <= 0)
        {
            SpawnEnemy();
            SpawnTimer = SpawnTime;
        }
    }
    public void SpawnEnemy()
    {
        Vector2 spawnVector = new Vector2();
        Vector2 spawnPosition;
        spawnVector.x = Random.Range(-1f, 1f);
        spawnVector.y = Random.Range(-1f, 1f);
        spawnVector.Normalize();
        spawnPosition = (Vector2)pos.position + spawnVector * size;
        if (Physics2D.OverlapCircle(spawnPosition, 0, AllowedSpawn))
        {
            Debug.Log("Spawn");
            EnemyPool.GetPooledObject(spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.Log("Try Again");
            SpawnEnemy();
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(pos.position, size);
    }
}

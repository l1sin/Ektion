using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform Pos;
    public float Size;
    public GameObject Prefab;

    public float SpawnPerMinute;
    public float SpawnTimer;
    public float SpawnTime;

    public ObjectPool EnemyPool;
    public LayerMask AllowedSpawn;

    public Transform Character;

    public EnemyData[] EnemyDatas;

    public int EnemyIndex;

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
            SpawnEnemy(EnemyIndex);
            SpawnTimer = SpawnTime;
        }
    }
    public void SpawnEnemy(int enemyIndex)
    {
        Vector2 spawnVector = new Vector2();
        Vector2 spawnPosition;
        spawnVector.x = Random.Range(-1f, 1f);
        spawnVector.y = Random.Range(-1f, 1f);
        spawnVector.Normalize();
        spawnPosition = (Vector2)Pos.position + spawnVector * Size;
        if (Physics2D.OverlapCircle(spawnPosition, 0, AllowedSpawn))
        {
            GameObject enemyObject = EnemyPool.GetPooledObject(spawnPosition, Quaternion.identity);
            Enemy enemy = enemyObject.GetComponent<Enemy>();
            enemy.Character = Character;
            enemy.SetStats(EnemyDatas[enemyIndex]);
        }
        else
        {
            SpawnEnemy(enemyIndex);
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(Pos.position, Size);
    }
}

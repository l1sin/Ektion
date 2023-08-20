using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Entities")]
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject[] _enemies;
    [SerializeField] private GameObject _boss;

    [Header("Spawn area")]
    [SerializeField] private LayerMask _forbidSpawn;
    [SerializeField] private float _spawnAreaRadius;

    [Header("Spawn rate")]
    [SerializeField] private float _spawnPerMin;
    private float _spawnCooldown;
    private float _cooldownTimer;
    private int _enemyTier;

    [Header("Containers")]
    [SerializeField] private GameObject _enemyContainer;
    [SerializeField] private GameObject _collectibleContainer;

    private bool _bossSpawned = false;


    private void Start()
    {
        _spawnCooldown = 60 / _spawnPerMin;
        _cooldownTimer = _spawnCooldown;
    }
    private void Update()
    {
        if (_player != null)
        {
            SpawnEnemies();
            if (!_bossSpawned && _enemyTier >= _enemies.Length)
            {
                SpawnBoss();
                _bossSpawned = true;
                AudioManager.Instance.BossSpawned = true;
                AudioManager.Instance.AudioSource.clip = AudioManager.Instance.BossMusic;
                AudioManager.Instance.AudioSource.Play();
            }
        } 
    }

    private GameObject InstantiateEnemy(GameObject enemy)
    {
        Vector3 randomPoint = _player.transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized * _spawnAreaRadius;
        if (!Physics2D.OverlapCircle(randomPoint, 0.1f, _forbidSpawn))
        {
            enemy = Instantiate(enemy, randomPoint, Quaternion.Euler(Vector3.zero));
            enemy.GetComponent<EnemyMovement>().Target = _player;
            if (enemy.TryGetComponent(out EnemyDrop drop))
            {
                drop.GetComponent<EnemyDrop>().CollectibleContainer = _collectibleContainer;
            }
            return enemy;
        }
        else
        {
            return InstantiateEnemy(enemy);
        }
    }
    private void SpawnEnemies()
    {
        _cooldownTimer -= Time.deltaTime;
        if (_cooldownTimer <= 0)
        {
            _cooldownTimer = _spawnCooldown;
            var enemy = ChooseEnemyToSpawn();
            if (enemy)
            {
                var newEnemy = InstantiateEnemy(enemy);
                newEnemy.transform.SetParent(_enemyContainer.transform);
            }
        }
    }
    private GameObject ChooseEnemyToSpawn()
    {
        GameObject enemyToSpawn;
        float random = Random.Range(0f, 1f);
        float probabilityToSpawnTierUp = UI.Instance.Seconds / 60;
        _enemyTier = (int)UI.Instance.Minutes + 1;
        if (_enemyTier < _enemies.Length)
        {
            if (random > probabilityToSpawnTierUp)
            {
                enemyToSpawn = _enemies[_enemyTier];
            }
            else
            {
                if (_enemyTier + 1 < _enemies.Length)
                {
                    enemyToSpawn = _enemies[_enemyTier + 1];
                }
                else
                {
                    return null;
                }
            }
        }
        else
        {
            return null;
        }
        return enemyToSpawn;
    }

    private void SpawnBoss()
    {
        InstantiateEnemy(_boss);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(_player.transform.position, _spawnAreaRadius);
    }
}

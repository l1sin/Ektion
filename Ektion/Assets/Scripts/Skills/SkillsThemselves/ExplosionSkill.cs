using UnityEngine;

public class ExplosionSkill : Skill
{
    [Header("Parameters")]
    [SerializeField] private float _cooldown = 3f;
    [SerializeField] private float _radius = 3f;
    [SerializeField] private float _damage = 20f;
    [SerializeField] private float _explosionRadius = 1f;  
    private float _cooldownTimer;

    [Header("LevelUp Increase")]
    [SerializeField] private float _cooldownDecrease = 0.5f;
    [SerializeField] private float _radiusIncrease = 1f;
    [SerializeField] private float _damageIncrease = 20f;
    [SerializeField] private float _explosionRadiusIncrease = 0.25f;

    [Header("Other")]
    [SerializeField] private GameObject _effect;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private GameObject _sound;

    private void Awake()
    {
        _cooldownTimer = _cooldown;
    }

    private void Update()
    {
        if (Time.timeScale != 0)
        {
            _cooldownTimer -= Time.deltaTime;
            if (_cooldownTimer <= 0)
            {
                AttivateSkill();
                _cooldownTimer = _cooldown;
            }
        }
    }

    public override void LevelUpSkill()
    {
        _cooldown -= _cooldownDecrease;
        _radius += _radiusIncrease;
        _damage += _damageIncrease;
        _explosionRadius += _explosionRadiusIncrease;
    }

    public override void AttivateSkill()
    {
        var hit = Physics2D.OverlapCircle(transform.position, _radius, _layerMask);
        if (hit != null)
        {
            var damagedEnemies = Physics2D.OverlapCircleAll(hit.transform.position, _explosionRadius, _layerMask);
            if (damagedEnemies != null)
            {
                foreach (var enemy in damagedEnemies)
                {
                    enemy.gameObject.GetComponent<Health>().GetDamage(_damage);
                }
            }
            Instantiate(_effect, hit.transform.position, Quaternion.Euler(Vector3.zero));
            Instantiate(_sound, hit.transform.position, Quaternion.Euler(Vector3.zero));
        }
        else
        {
            var RandomPos = transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized * Random.Range(0, _radius);
            var damagedEnemies = Physics2D.OverlapCircleAll(RandomPos, _explosionRadius, _layerMask);
            if (damagedEnemies != null)
            {
                foreach (var enemy in damagedEnemies)
                {
                    enemy.gameObject.GetComponent<Health>().GetDamage(_damage);
                }
            }
            Instantiate(_effect, RandomPos, Quaternion.Euler(Vector3.zero));
            Instantiate(_sound, RandomPos, Quaternion.Euler(Vector3.zero));
        }
    }
}

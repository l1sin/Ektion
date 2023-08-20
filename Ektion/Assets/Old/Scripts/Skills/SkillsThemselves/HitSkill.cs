using UnityEngine;

public class HitSkill : Skill
{
    [Header("Parameters")]
    [SerializeField] private float _cooldown = 1f;
    [SerializeField] private float _radius = 3f;
    [SerializeField] private float _damage = 10f;
    private float _cooldownTimer;


    [Header("LevelUp Increase")]
    [SerializeField] private float _cooldownDecrease = 0.2f;
    [SerializeField] private float _radiusIncrease = 1f;
    [SerializeField] private float _damageIncrease = 15f;

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
    }

    public override void AttivateSkill()
    {
        var hit = Physics2D.OverlapCircle(transform.position, _radius, _layerMask);
        if (hit != null)
        {
            hit.gameObject.GetComponent<Health>().GetDamage(_damage);
            Instantiate(_effect, hit.transform.position, Quaternion.Euler(Vector3.zero));
            Instantiate(_sound, hit.transform.position, Quaternion.Euler(Vector3.zero));

        }
        else
        {
            var RandomPos = transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized * Random.Range(0, _radius);
            Instantiate(_effect, RandomPos, Quaternion.Euler(Vector3.zero));
            Instantiate(_sound, RandomPos, Quaternion.Euler(Vector3.zero));
        }
    }
}

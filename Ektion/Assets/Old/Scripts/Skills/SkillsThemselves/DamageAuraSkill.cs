using UnityEngine;

public class DamageAuraSkill : Skill
{
    [Header("Parameters")]
    [SerializeField] private float _cooldown = 0.5f;
    [SerializeField] private float _radius = 2f;
    [SerializeField] private float _damage = 1f;
    private float _cooldownTimer;

    [Header("LevelUp Increase")]
    [SerializeField] private float _cooldownDecrease = 0.1f;
    [SerializeField] private float _radiusIncrease = 0.5f;
    [SerializeField] private float _damageIncrease = 1f;

    [Header("Other")]
    [SerializeField] private GameObject _effect;
    [SerializeField] private LayerMask _layerMask;

    private void Awake()
    {
        _cooldownTimer = _cooldown;
    }
    private void Start()
    {
        var effect = Instantiate(_effect, transform.position, transform.rotation);
        effect.transform.parent = transform;
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
        var hits = Physics2D.OverlapCircleAll(transform.position, _radius, _layerMask);
        if (hits != null)
        {
            foreach (var hit in hits)
            {
                hit.gameObject.GetComponent<Health>().GetDamage(_damage);
            }
        }
    }
}

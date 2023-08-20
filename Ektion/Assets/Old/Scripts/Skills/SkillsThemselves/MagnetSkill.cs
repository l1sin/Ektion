using UnityEngine;

public class MagnetSkill : Skill
{
    [Header("Parameters")]
    [SerializeField] private float _radius = 1f;
    [SerializeField] private float _magnetSpeed = 1f;

    [Header("LevelUp Increase")]
    [SerializeField] private float _radiusIncrease = 1f;
    [SerializeField] private float _magnetSpeedIncrease = 2f;

    [Header("Other")]
    [SerializeField] private LayerMask _layerMask;

    private void Update()
    {
        AttivateSkill();
    }

    public override void LevelUpSkill()
    {
        _radius += _radiusIncrease;
        _magnetSpeed += _magnetSpeedIncrease;
    }

    public override void AttivateSkill()
    {
        var collectibles = Physics2D.OverlapCircleAll(transform.position, _radius, _layerMask);
        foreach (var collectible in collectibles)
        {
            collectible.transform.position = Vector3.MoveTowards(collectible.transform.position, transform.position, _magnetSpeed * Time.deltaTime);
        }
    }
}

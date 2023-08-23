using UnityEngine;
[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObject/EnemyData")]

public class EnemyData : ScriptableObject
{
    public float MaxHP;
    public float Speed;
    public float ContactDamage;
    public int DropLevel;
    public Sprite EnemySprite;
}

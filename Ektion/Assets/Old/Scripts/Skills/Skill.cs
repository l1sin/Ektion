using UnityEngine;

public class Skill : MonoBehaviour
{
    [Header("Main")]
    public float SkillLevel = 1;
    public float SkillCap = 5;
    public Sprite SkillImage;

    public virtual void LevelUpSkill()
    {

    }
    public virtual void AttivateSkill()
    {

    }
}

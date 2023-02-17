using System;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance { get; private set; }
    [SerializeField] private GameObject _skillContainer;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public void ModifySkills(GameObject skillToAdd)
    {
        Type type = skillToAdd.GetComponent(typeof(Skill)).GetType();
        var existingSkill = (Skill)FindObjectOfType(type);

        if (!existingSkill)
        {
            var newSkill = Instantiate(skillToAdd, _skillContainer.transform.position, _skillContainer.transform.rotation);
            newSkill.transform.SetParent(_skillContainer.transform);
        }
        else
        {
            UpgradeSkill(existingSkill);
        }
    }

    private void UpgradeSkill(Skill skill)
    {
        skill.SkillLevel++;
        skill.LevelUpSkill();
    }
}

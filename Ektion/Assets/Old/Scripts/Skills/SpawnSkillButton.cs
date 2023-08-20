using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SpawnSkillButton : MonoBehaviour
{
    [SerializeField] private int _buttonsSpawned;
    [SerializeField] private GameObject[] _skills;
    [SerializeField] private GameObject _button;

    private List<GameObject> _skillVariants = new List<GameObject>();

    private void Start()
    {
        UI.Instance.CanUnpause = false;
        MakeListOfAllowedSkills();
        if (_skillVariants.Count != 0)
        {
            MakeSpawnList();
            TossList();
            SpawnButtons();
        }
    }


    private void MakeListOfAllowedSkills()
    {
        foreach (GameObject variant in _skills)
        {
            Type type = variant.GetComponent(typeof(Skill)).GetType();
            var existingSkill = (Skill)FindObjectOfType(type);
            if (!existingSkill)
            {
                _skillVariants.Add(variant);
            }
            else
            {
                if (existingSkill.SkillLevel < variant.GetComponent<Skill>().SkillCap)
                {
                    _skillVariants.Add(variant);
                }
            }       
        }
        if (_skillVariants.Count == 0)
        {
            Time.timeScale = 1;
            Destroy(transform.parent.parent.gameObject);
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    private void MakeSpawnList()
    {
        for (int amountOfVariants = _skillVariants.Count; amountOfVariants > _buttonsSpawned; amountOfVariants--)
        {
            _skillVariants.Remove(_skillVariants[Random.Range(0, _skillVariants.Count)]);
        }
    }

    private void SpawnButtons()
    {
        foreach (GameObject skill in _skillVariants)
        {
            GameObject newButton = Instantiate(_button);
            SkillButton skillButton = newButton.GetComponent<SkillButton>();
            skillButton.Skill = skill;
            skillButton.transform.SetParent(transform);
            newButton.GetComponent<Image>().sprite = skill.GetComponent<Skill>().SkillImage;
        }
    }

    private void TossList()
    {
        for (int i = _skillVariants.Count - 1; i >= 1; i--)
        {
            int j = Random.Range(0,i + 1);
            var temp = _skillVariants[j];
            _skillVariants[j] = _skillVariants[i];
            _skillVariants[i] = temp;
        }
    }
}

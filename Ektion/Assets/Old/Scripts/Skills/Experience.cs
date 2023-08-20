using UnityEngine;

public class Experience : MonoBehaviour
{
    public static Experience Instance { get; private set; }

    [Header("Level info")]
    [SerializeField] private int _level;
    [SerializeField] private float _experience;
    [SerializeField] private float _experienceNextLvl;
    [SerializeField] private float _experiencePrevLvl;
    public float ExperineceAtThisLvl;
    public float ExperineceProgressAtThisLevel;
    public bool AllowLevelUp = true;

    [Header("Sound")]
    [SerializeField] private GameObject _levelUpSound;

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

        SetStartExperience();
    }

    public void GetExperience(int gainExperience)
    {
        _experience += gainExperience;
        CheckIfLevelUp();
    }

    public void CheckIfLevelUp()
    {
        if (_experience >= _experienceNextLvl && AllowLevelUp)
        {
            LevelUp();
        }
        ExperineceProgressAtThisLevel = _experience - _experiencePrevLvl;
    }

    private void SetStartExperience()
    {
        _level = 0;
        _experience = 0;
        _experiencePrevLvl = 0;
        _experienceNextLvl = 10;
        ExperineceAtThisLvl = _experienceNextLvl - _experiencePrevLvl;
        ExperineceProgressAtThisLevel = _experience - _experiencePrevLvl;
    }
    private void LevelUp()
    {
        AllowLevelUp = false;
        _level++;
        _experiencePrevLvl = _experienceNextLvl;
        _experienceNextLvl = _experiencePrevLvl + 12 * (_level + 1);
        ExperineceAtThisLvl = _experienceNextLvl - _experiencePrevLvl;
        Instantiate(_levelUpSound, transform.position, transform.rotation);
        UI.Instance.SpawnMenu(UI.Instance._menus[1]);
    }
}

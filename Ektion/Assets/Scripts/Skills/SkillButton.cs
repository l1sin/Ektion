using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    [SerializeField] private UnityAction _action;
    public GameObject Skill;


    private void Awake()
    {
        var button = GetComponent<Button>();
        _action += DoStuff;
        button.onClick.AddListener(_action);
    }

    private void Start()
    {
        transform.localScale = Vector3.one;
    }

    private void DoStuff()
    {
        SkillManager.Instance.ModifySkills(Skill);
        Destroy(transform.parent.parent.parent.gameObject);
        Experience.Instance.AllowLevelUp = true;
        Experience.Instance.CheckIfLevelUp();
        UI.Instance.CanUnpause = true;
        Time.timeScale = 1;
    }
}

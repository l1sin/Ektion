using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [Header("References")]
    public GameObject[] _menus;
    [SerializeField] private Image _expLine;
    [SerializeField] private Image _hPLine;
    [SerializeField] private PlayerHealth _playerHealth;

    [Header("Timer")]
    [SerializeField] private TextMeshProUGUI _timerText;
    [HideInInspector] public bool TimerStarted = false;
    public float Seconds;
    public float Minutes;

    [Header("Pause")]
    [HideInInspector] public bool CanUnpause;
    [HideInInspector] public bool Paused;
    private GameObject _pauseMenu;

    public static UI Instance { get; private set; }

    private void Awake()
    {
        Time.timeScale = 1;
        CanUnpause = true;
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        ShowExpLine();
        ShowHPLine();
        Pause();
        if (TimerStarted)
        {
            Timer();
        }
    }

    private void ShowExpLine()
    {
        if (Experience.Instance != null)
        {
            _expLine.fillAmount = Experience.Instance.ExperineceProgressAtThisLevel / Experience.Instance.ExperineceAtThisLvl;
        }
    }

    private void ShowHPLine()
    {
        if (_playerHealth != null && _hPLine != null)
        {
            _hPLine.fillAmount = _playerHealth.CurrentHealth / _playerHealth.MaxHealth;
            if (_hPLine.fillAmount == 1)
            {
                _hPLine.transform.parent.gameObject.SetActive(false);
            }
            else
            {
                _hPLine.transform.parent.gameObject.SetActive(true);
            }
        }
    }

    public GameObject SpawnMenu(GameObject menu)
    {
        Time.timeScale = 0;
        var newMenu = Instantiate(menu);
        newMenu.transform.SetParent(transform.parent, false);
        return newMenu;
    }
    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!Paused)
            {
                _pauseMenu = SpawnMenu(_menus[2]);
                Paused = true;
            }
            else
            {
                Destroy(_pauseMenu);
                Paused = false;
                if (CanUnpause)
                {
                    Time.timeScale = 1;
                }
            }
        }
    }

    private void Timer()
    {
        Seconds += Time.deltaTime;
        if (Seconds >= 60)
        {
            Minutes++;
            Seconds -= 60;
        }
        if (Seconds <= 10)
        {
            _timerText.text = Minutes + ":0" + (int)Seconds;
        }
        else
        {
            _timerText.text = Minutes + ":" + (int)Seconds;
        }
    }
}

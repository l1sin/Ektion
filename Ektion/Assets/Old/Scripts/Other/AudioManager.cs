using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource AudioSource;

    [Header("Clips")]
    [SerializeField] private AudioClip[] _music;
    public AudioClip BossMusic;
    public AudioClip WinMusic;
    [HideInInspector] public bool BossSpawned;
    public static AudioManager Instance { get; private set; }

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
        StartMusic();
    }

    private void Update()
    {
        if (!BossSpawned)
        {
            ChangeTrack();
        }
        else
        {
            if (!AudioSource.isPlaying)
            {
                AudioSource.Play();
            }
        }
    }

    private void StartMusic()
    {
        AudioSource.clip = _music[Random.Range(0, _music.Length)];
        AudioSource.Play();
    }

    private void ChangeTrack()
    {
        if (!AudioSource.isPlaying)
        {
            StartMusic();
        }
    }
}

using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private void Update()
    {
        if (!_audioSource.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}

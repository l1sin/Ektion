using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private int _experienceValue;
    [SerializeField] private Experience _experienceComponent;
    [SerializeField] private GameObject _collectSound;

    public void Collect(Experience gainer)
    {
        gainer.GetExperience(_experienceValue);
        Instantiate(_collectSound, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

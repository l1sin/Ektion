using UnityEngine;

public class Experience : MonoBehaviour
{
    public static Experience Instance;
    public float Exp;
    public int Level;

    private void Awake()
    {
        if (Instance != null & Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void GetExperience(int exp)
    {
        Exp += exp;
    }
}

using UnityEngine;

public class ExpDrop : MonoBehaviour
{
    public int expValue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Experience.Instance.GetExperience(expValue);
        gameObject.SetActive(false);
    }
}

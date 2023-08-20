using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    [SerializeField] private GameObject[] _expDrops;
    [SerializeField] private int _enemyExperienceValue;
    [SerializeField] private float _dropSpeed;
    private int _totalTiers = 8;
    public GameObject CollectibleContainer;

    private void Start()
    {
        _totalTiers = _expDrops.Length;
    }

    // Convert enemy experience value into collectibles.
    public void CalculateAndDrop()
    {
        int expLeftToCalculate = _enemyExperienceValue;
        int currentTierIndex = _totalTiers - 1;
        int division = (int)Mathf.Pow(2, currentTierIndex);

        while (expLeftToCalculate > 0)
        {
            int dropAmount = expLeftToCalculate / division;
            expLeftToCalculate -= dropAmount * division;
            division /= 2;
            while (dropAmount > 0)
            {
                DropExp(_expDrops[currentTierIndex]);
                dropAmount--;
            }
            currentTierIndex--;
        }
    }

    // Drop collectible with some velocity.
    public void DropExp(GameObject exp)
    {
        var drop = Instantiate(exp, transform.position, transform.rotation);
        Vector3 dropDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
        drop.gameObject.GetComponent<Rigidbody2D>().velocity = dropDirection * _dropSpeed;
        drop.transform.SetParent(CollectibleContainer.transform);
    }
}

using UnityEngine;

public class StartTrigger : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _spawner;
    [SerializeField] private GameObject _goodSound;

    [Header("Gizmos")]
    [SerializeField] private Vector3 _size;
    [SerializeField] private LayerMask _layerMask;

    private void Update()
    {
        if (Physics2D.OverlapBox(transform.position, _size, 0, _layerMask))
        {
            UI.Instance.SpawnMenu(UI.Instance._menus[0]);
            UI.Instance.TimerStarted = true;
            Instantiate(_goodSound, transform.position, transform.rotation);
            _spawner.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, _size);
    }
}

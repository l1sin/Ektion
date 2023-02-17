using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _damagePerSecond;

    [Header("Gizmos")]
    [SerializeField] private Vector3 _size;
    [SerializeField] private Vector3 _offset;

    private void Update()
    {
        var hit = Physics2D.OverlapBox(transform.position + _offset, _size, 0, _layerMask);
        if (hit)
        {
            hit.gameObject.GetComponent<PlayerHealth>().GetDamage(_damagePerSecond * Time.deltaTime);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + _offset, _size);
    }
}

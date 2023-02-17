using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _followTarget;
    [SerializeField] private Vector3 _offset;

    private void Update()
    {
        if (_followTarget != null)
        {
            transform.position = _followTarget.position + _offset;
        }
    }
}

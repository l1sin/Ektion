using UnityEngine;

public class Effect : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName(GlobalStrings.AnimEnded))
        {
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

[RequireComponent(typeof(Experience))]
public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Experience _experienceComponent;
    [SerializeField] private LayerMask _layerMask;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            collision.gameObject.GetComponent<Collectible>().Collect(_experienceComponent);       
        }
    }
}

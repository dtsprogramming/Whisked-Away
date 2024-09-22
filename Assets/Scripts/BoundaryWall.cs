using UnityEngine;
using UnityEngine.Events;

public class BoundaryWall : MonoBehaviour
{
    [SerializeField] private UnityEvent onBoundaryHit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            onBoundaryHit.Invoke();
        }
    }
}

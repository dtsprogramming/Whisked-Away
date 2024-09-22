using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float pushForce = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object is the projectile
        if (other.CompareTag("Projectile"))
        {
            // Assuming the target has a Rigidbody2D component
            Rigidbody2D targetRigidbody = GetComponent<Rigidbody2D>();
            if (targetRigidbody != null)
            {
                // Calculate the direction from the projectile to the target
                Vector2 impactDirection = (transform.position - other.transform.position).normalized;

                // Apply force to the target in the opposite direction
                targetRigidbody.AddForce(impactDirection * pushForce, ForceMode2D.Impulse);
                Destroy(gameObject, 2);
            }

            // Destroy the projectile on impact
            Destroy(other.gameObject);
        }
    }
}

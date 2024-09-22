using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f; // Speed of the projectile
    private Vector2 direction;

    void Update()
    {
        // Move the projectile in the set direction
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        Destroy(gameObject, 5f);
    }
}

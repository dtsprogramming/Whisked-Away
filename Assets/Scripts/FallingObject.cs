using UnityEngine;
using UnityEngine.Events;

public class FallingObject : MonoBehaviour
{
    [SerializeField] private int pointValue = 10;
    [SerializeField] private float pushForce = 0.1f;
    [SerializeField] private AudioClip[] impactSounds;

    private Camera mainCam;
    private AudioSource camAudio;
    
    private GameManager gameManager;

    private void Start()
    {
        mainCam = FindFirstObjectByType<Camera>();
        camAudio = mainCam.GetComponent<AudioSource>();
        gameManager = FindFirstObjectByType<GameManager>();
        Destroy(gameObject, 8);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object is the projectile
        if (other.CompareTag("Projectile"))
        {
            gameManager.IncreaseScore(pointValue);
            camAudio.PlayOneShot(impactSounds[Random.Range(0, impactSounds.Length)], 1);

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

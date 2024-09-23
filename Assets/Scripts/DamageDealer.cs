using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float damageAmount = 15f;
    [SerializeField] private AudioClip hitFX;

    private Camera mainCam;
    private AudioSource camAudio;

    private void Start()
    {
        mainCam = FindFirstObjectByType<Camera>();
        camAudio = mainCam.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            camAudio.PlayOneShot(hitFX);
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.DecreaseHealth(damageAmount);
        }
    }
}

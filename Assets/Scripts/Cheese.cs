using UnityEngine;
using UnityEngine.Events;

public class Cheese : MonoBehaviour
{
    [SerializeField] private float healthPoints = 10f;
    [SerializeField] private UnityEvent onCheeseEaten;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.IncreaseHealth(healthPoints);

            onCheeseEaten.Invoke();
        }
    }
}

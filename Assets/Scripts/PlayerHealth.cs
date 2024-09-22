using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float totalHealth = 100f;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private UnityEvent onPlayerDeath;

    public float CurrentHealth { get; private set; }

    void Start()
    {
        CurrentHealth = totalHealth;
        DisplayHealth();
    }

    private void Update()
    {
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            DisplayHealth();
            PlayerDeath();
        }
    }

    public void IncreaseHealth(float amount)
    {
        CurrentHealth += amount;

        if (CurrentHealth > totalHealth)
        {
            CurrentHealth = totalHealth;
        }

        DisplayHealth();
    }

    public void DecreaseHealth(float amount)
    {
        if (CurrentHealth >= 0)
        {
            CurrentHealth -= amount;
            DisplayHealth();
        }
    }

    private void PlayerDeath()
    {
        CurrentHealth = 0;
        DisplayHealth();
        onPlayerDeath.Invoke();
    }

    private void DisplayHealth()
    {
        healthText.text = $"PLAYER HEALTH: {CurrentHealth}";
    }
}

using UnityEngine;

public class WhiskerTrap : MonoBehaviour
{
    public GameObject targetObject; // The GameObject you want to activate/deactivate
    public float deactivationMinDelay = 5f; // Minimum time before deactivation
    public float deactivationMaxDelay = 8f; // Maximum time before deactivation
    public float activationDelay = 3f; // Fixed time to wait to activate the object

    private float nextChangeTime;
    private bool isActive;

    void Start()
    {
        // Initialize the GameObject to inactive
        targetObject.SetActive(false);
        isActive = false; // Start with the GameObject inactive
        nextChangeTime = Time.time + activationDelay; // Set the first activation delay
    }

    void Update()
    {
        // Check if it's time to change the state based on whether the object is active or not
        if (Time.time >= nextChangeTime)
        {
            if (isActive)
            {
                // Deactivate the target object after a random delay
                DeactivateWithRandomDelay();
            }
            else
            {
                // Activate the target object after a fixed time
                Activate();
            }
        }
    }

    void Activate()
    {
        targetObject.SetActive(true);
        isActive = true; // Mark as active
        // Schedule the next change time randomly for deactivation
        nextChangeTime = Time.time + Random.Range(deactivationMinDelay, deactivationMaxDelay);
    }

    void DeactivateWithRandomDelay()
    {
        targetObject.SetActive(false);
        isActive = false; // Mark as inactive
        // Schedule the next change time for activation
        nextChangeTime = Time.time + activationDelay; // Set a fixed time to activate again
    }
}

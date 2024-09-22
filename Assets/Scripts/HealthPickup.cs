using UnityEngine;
using UnityEngine.Events;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private GameObject leftCheese;
    [SerializeField] private GameObject rightCheese;

    private bool rightIsActive = true;

    public void SwapCheeseLocation()
    {
        if (rightIsActive)
        {
            rightCheese.SetActive(false);
            Invoke(nameof(ActivateLeftCheese), 2);
        }
        else
        {
            leftCheese.SetActive(false);
            Invoke(nameof(ActivateRightCheese), 2);
        }
    }

    private void ActivateLeftCheese()
    {
        leftCheese.SetActive(true);
        rightIsActive = false;
    }

    private void ActivateRightCheese()
    {
        rightCheese.SetActive(true);
        rightIsActive = true;
    }
}

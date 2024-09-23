using UnityEngine;
using UnityEngine.Events;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private GameObject leftCheese;
    [SerializeField] private GameObject rightCheese;
    [SerializeField] private AudioSource mainCam;
    [SerializeField] private AudioClip eatCheese;

    private bool rightIsActive = true;

    public void SwapCheeseLocation()
    {
        if (rightIsActive)
        {
            rightCheese.SetActive(false);
            mainCam.PlayOneShot(eatCheese);
            Invoke(nameof(ActivateLeftCheese), 2);
        }
        else
        {
            leftCheese.SetActive(false);
            mainCam.PlayOneShot(eatCheese);
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

using System.Collections;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [SerializeField] GameObject pilotLight;
    [SerializeField] GameObject fire;
    [SerializeField] float fireOnDelay = 0.7f;
    [SerializeField] int fireOffMinDelay = 2;
    [SerializeField] int fireOffMaxDelay = 4;

    private bool isOff = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOff)
        {
            isOff = false;
            BurnerOn();
        }
    }

    private void BurnerOn()
    {
        int randDelay = Random.Range(4, 8);

        Invoke("LetItBurn", randDelay);
    }

    private void LetItBurn()
    {
        pilotLight.SetActive(true);

        StartCoroutine(FlameOn());
    }

    private IEnumerator FlameOn()
    {
        yield return new WaitForSeconds(fireOnDelay);

        fire.SetActive(true);

        yield return new WaitForSeconds(Random.Range(fireOffMinDelay, fireOffMaxDelay));

        pilotLight.SetActive(false);
        fire.SetActive(false);
        isOff = true;
    }
}

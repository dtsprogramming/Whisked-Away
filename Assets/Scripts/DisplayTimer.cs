using System;
using TMPro;
using UnityEngine;

public class DisplayTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;

    private float elapsedTime = 0f;
    private TimeSpan timePlaying;
    private bool isAlive = true;

    void Update()
    {
        if (isAlive)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);

            string timePlayed = $"SURVIVAL TIME: {timePlaying.ToString("mm':'ss'.'ff")}";
            timerText.text = timePlayed;
        }
    }

    public void SetAliveBool()
    {
        isAlive = false;
    }
}

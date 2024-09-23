using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerScore { get; private set; }
    [SerializeField] private TextMeshProUGUI scoreText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore(int amount)
    {
        playerScore += amount;
        DisplayScore();
    }

    private void DisplayScore()
    {
        scoreText.text = $"SCORE: {playerScore}";
    }
}

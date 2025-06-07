using UnityEngine;
using TMPro; // Importing TMPro for TextMeshPro support

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TMP_Text scoreText;

    public TMP_Text remainingText;

    public int targetCount = 0;

    public int score = 0; // Initialize score to 0

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // Set the singleton instance
            DontDestroyOnLoad(gameObject); // Prevent this object from being destroyed on scene load
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RegisterTarget()
    {
        targetCount++; // Increment the target count when a target is registered

        if (remainingText != null)
        {
            remainingText.text = "Remaining: " + targetCount; // Update the remaining targets text
        }
    }

    public void UnregisterTarget()
    {
        targetCount--;

        if (remainingText != null)
        {
            remainingText.text = "Remaining: " + targetCount; // Update the remaining targets text
        }

        if (targetCount < 0) targetCount = 0;
        {
            CheckVictory(); // <-- Add this line
        }
        
    }

    private bool gameEnded = false;

    public void PlayerDied()
    {
        if (!gameEnded)
        {
            Debug.Log("Failure");
            gameEnded = true;
        }
    }

    public void CheckVictory()
    {
        if (targetCount <= 0 && !gameEnded)
        {
            Debug.Log("Victory");
            gameEnded = true;
        }
    }

    public void AwardPoints(int pointsAwarded)
    {
        score += pointsAwarded; // Increment the score by the awarded points
        // score = score + pointsAwarded; is an alternative way to increment the score

        if (scoreText != null)
        {
            scoreText.text = "Score: " + score; // Update the score text
        }
    }

}

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int targetCount = 0;

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
    }

    public void UnregisterTarget()
    {
        targetCount--;
        if (targetCount < 0) targetCount = 0;

        CheckVictory(); // <-- Add this line
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

}

using UnityEngine;
using UnityEngine.UI; // Importing necessary UnityEngine namespaces for UI components
using UnityEngine.SceneManagement; // Importing UnityEngine.SceneManagement for scene management

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Load the game scene (assuming the game scene is named "GameScene")
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    public void OptionsMenu()
    {

    }
    
    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
        
        Debug.Log("Game is quitting..."); // Log message for debugging purposes
    }
}

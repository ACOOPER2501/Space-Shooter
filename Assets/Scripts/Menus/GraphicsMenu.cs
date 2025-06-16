using UnityEngine;
using UnityEngine.UI; // Importing necessary UnityEngine namespaces for UI components
using UnityEngine.SceneManagement; // Importing UnityEngine.SceneManagement for scene management
using System.Collections;
using System.Collections.Generic; // Importing necessary namespaces for collections
using TMPro;
using Unity.VisualScripting; // Importing TMPro for TextMeshPro support

public class GraphicsMenu : MonoBehaviour
{

    public Toggle fullscreenTog, vsyncTog;

    public List<ResItem> resolutions = new List<ResItem>(); // List to hold available resolutions

    private int selectedResolution; // Index of the currently selected resolution

    public TMP_Text resolutionLabel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        fullscreenTog.isOn = Screen.fullScreen; // Set the toggle state based on the current fullscreen mode

        if (QualitySettings.vSyncCount == 0) // Check if VSync is disabled
        {
            vsyncTog.isOn = false; // Set the toggle state to off if VSync is disabled
        }
        else
        {
            vsyncTog.isOn = true; // Set the toggle state to on if VSync is enabled
        }
        //Note: isOn is a property of the Toggle class that returns true if the toggle is currently on, and false if it is off.

        bool foundResolution = false; // Flag to check if the current screen resolution is found in the list
        for (int i = 0; i < resolutions.Count; i++) // Loop through the list of resolutions
        {//Note: i is the index of the current resolution in the list
            // Check if the current screen resolution matches any in the list
            if (Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundResolution = true; // Check if the current screen resolution matches any in the list

                selectedResolution = i; // Set the selected resolution index to the matching resolution

                UpdateResLabel();
            }
        }

        //This will be used for the case where the player's current screen resolution is not found in the list of resolutions.
        if (!foundResolution) // If the current screen resolution is not found in the list
        {
            ResItem newRes = new ResItem(); // Create a new ResItem instance
            newRes.horizontal = Screen.width; // Set the horizontal dimension to the current screen width
            newRes.vertical = Screen.height; // Set the vertical dimension to the current screen height

            resolutions.Add(newRes); // Add the new resolution to the list
            selectedResolution = resolutions.Count - 1; // Set the selected resolution index to the last added resolution
            UpdateResLabel(); // Update the resolution label to reflect the new resolution
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResLeft()
    {
        selectedResolution--; // Decrease the selected resolution index
        if (selectedResolution < 0)
        {
            selectedResolution = 0; // Ensure the index does not go below 0
        }

        UpdateResLabel(); // Update the resolution label to reflect the new selected resolution
    }

    public void ResRight()
    {
        selectedResolution++; // Increase the selected resolution index
        if (selectedResolution > resolutions.Count - 1)
        {
            selectedResolution = resolutions.Count - 1; // Ensure the index does not exceed the last resolution index
        }

        UpdateResLabel(); // Update the resolution label to reflect the new selected resolution
    }

    public void UpdateResLabel()
    {
        // Update the resolution label with the selected resolution
        resolutionLabel.text = resolutions[selectedResolution].horizontal.ToString() + " x " +
                               resolutions[selectedResolution].vertical.ToString();
    }


    public void ApplyGraphics()
    {
        //Screen.fullScreen = fullscreenTog.isOn; // Apply fullscreen setting based on the toggle state

        if(vsyncTog.isOn) // Check if VSync toggle is on
        {
            QualitySettings.vSyncCount = 1; // Enable VSync
        }
        else
        {
            QualitySettings.vSyncCount = 0; // Disable VSync
        }

        //Apply the selected resolution
        //This checks both the horizontal and vertical dimensions of the selected resolution
        Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].vertical, fullscreenTog.isOn);
    }

}

//using [System.Serializable] to make the ResItem class serializable,
//allowing it to be used in the Unity Inspector and serialized by Unity's serialization system.
//In short, making it visible to us in inspector and allowing us to edit it in the Unity Editor.
[System.Serializable]
public class ResItem
{
    public int horizontal, vertical; // Resolution dimensions
}



//Developer Note: We could use the gameObject.SetActive(false) or gameObject.SetActive(true); to manipulate the visibility of the options menu.
//However, we will use the Unity UI system to manage the visibility of the options menu.
//We accomplished this by using the button component in the Unity UI system to toggle the visibility of the options menu.
//This was done by using the "On Click" event, using "Editor And Runtime", "GameObject.SetActive", then clicking the box.
//This sets each individual button to toggle the visibility of the options menu.

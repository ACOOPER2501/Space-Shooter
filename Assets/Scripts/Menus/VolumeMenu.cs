using UnityEngine;
using UnityEngine.UI; // Importing necessary UnityEngine namespaces for UI components
using UnityEngine.SceneManagement; // Importing UnityEngine.SceneManagement for scene management
using System.Collections;
using System.Collections.Generic; // Importing necessary namespaces for collections
using TMPro;
using Unity.VisualScripting; // Importing TMPro for TextMeshPro support
using UnityEngine.Audio; // Importing UnityEngine.Audio for audio management

public class VolumeMenu : MonoBehaviour
{
    public AudioMixer theMixer; // Reference to the AudioMixer for volume control

    public TMP_Text mastLabel, musicLabel, sfxLabel; // Text labels for Master, Music, and SFX volume

    public Slider mastSlider, musicSlider, sfxSlider; // Sliders for adjusting Master, Music, and SFX volume

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float vol = 0f; // Initialize volume variable

        // Check if Master volume setting exists in PlayerPrefs
        theMixer.GetFloat("MasterVol", out vol);
        mastSlider.value = vol;
        // Set the Master volume slider to the value stored in PlayerPrefs
        theMixer.GetFloat("MusicVol", out vol);
        musicSlider.value = vol;
        // Set the Music volume slider to the value stored in PlayerPrefs
        theMixer.GetFloat("SFXVol", out vol);
        sfxSlider.value = vol;

        // Set the Master, Music, & SFX volume sliders to the value stored in PlayerPrefs
        mastLabel.text = Mathf.RoundToInt(mastSlider.value + 80).ToString();
        musicLabel.text = Mathf.RoundToInt(musicSlider.value + 80).ToString();
        sfxLabel.text = Mathf.RoundToInt(sfxSlider.value + 80).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMasterVol()
    {
        // Set the Master volume in the AudioMixer based on the value of the mastSlider
        //Mathf.RoundToInt(mastSlider.value + 80) converts the slider value to a range suitable for the AudioMixer
        //Mathf.RoundToInt rounds the value to the nearest integer, so the player will see whole numbers in the UI
        //We add 80 because the AudioMixer expects a range from -80 to 0 for volume levels
        //This way, we can have our slider range from 0 to 80, which is more user-friendly
        mastLabel.text = Mathf.RoundToInt(mastSlider.value + 80).ToString();

        //Allows the AudioMixer to set the Master volume based on the slider value
        theMixer.SetFloat("MasterVol", mastSlider.value); // Set the Master volume in the AudioMixer

        //This stores the Master volume setting in PlayerPrefs, so that it can be saved and loaded later between game sessions.
        PlayerPrefs.SetFloat("MasterVol", mastSlider.value);
    }

    public void SetMusicVol()
    {
        // This method sets the Music volume in the AudioMixer based on the value of the musicSlider
        musicLabel.text = Mathf.RoundToInt(musicSlider.value + 80).ToString();

        // Allows the AudioMixer to set the Music volume based on the slider value
        theMixer.SetFloat("MusicVol", musicSlider.value);

        //This stores the Music volume setting in PlayerPrefs, so that it can be saved and loaded later between game sessions.
        PlayerPrefs.SetFloat("MusicVol", musicSlider.value);
    }

    public void SetSFXVol()
    {
        //This method sets the SFX volume in the AudioMixer based on the value of the sfxSlider
        sfxLabel.text = Mathf.RoundToInt(sfxSlider.value + 80).ToString();

        // Allows the AudioMixer to set the SFX volume based on the slider value
        theMixer.SetFloat("SFXVol", sfxSlider.value);

        //This stores the SFX volume setting in PlayerPrefs, so that it can be saved and loaded later between game sessions.
        PlayerPrefs.SetFloat("SFXVol", sfxSlider.value);
    }
}

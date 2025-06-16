using System.Collections;
using System.Collections.Generic; // Importing necessary namespaces for collections
using UnityEngine;
using UnityEngine.Audio; // Importing UnityEngine.Audio for audio management

public class AudioManager : MonoBehaviour
{

    public AudioMixer theMixer; // Reference to the AudioMixer for volume control

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(PlayerPrefs.HasKey("MasterVol")) // Check if Master volume setting exists in PlayerPrefs
        {
            theMixer.SetFloat("MasterVol", PlayerPrefs.GetFloat("MasterVol")); // Set the Master volume in the AudioMixer
        }
     

        if(PlayerPrefs.HasKey("MusicVol")) // Check if Music volume setting exists in PlayerPrefs
        {
            theMixer.SetFloat("MusicVol", PlayerPrefs.GetFloat("MusicVol")); // Set the Music volume in the AudioMixer
        }
       

        if(PlayerPrefs.HasKey("SFXVol")) // Check if SFX volume setting exists in PlayerPrefs
        {
            theMixer.SetFloat("SFXVol", PlayerPrefs.GetFloat("SFXVol")); // Set the SFX volume in the AudioMixer
        }
      
    }

}

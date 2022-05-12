using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarDrumsTheme : MonoBehaviour
{
    public AudioSource WarDrums = new();

    private AudioSource m_AudioSource; // reference to the audio source


    /// <summary>
    /// Intial setup of Gauntlet Round One Music
    /// </summary>
    public void InitialiseRoundMusic()
    {
        Debug.Log("Initialising Gauntlet Round Music");
        
        m_AudioSource = GetComponent<AudioSource>();
        RoundOneDrums();
        Debug.Log("Gauntlet Music Setup, Background Music should have changed");
    }

    /// <summary>
    ///  Setup Audio for round one
    /// </summary>
    public void RoundOneDrums()
    {
        
        Debug.Log("All Music Should Stop and then...the drums should start next");
        m_AudioSource.Play();
    }


}

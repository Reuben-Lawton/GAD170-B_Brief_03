using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    // public List<AudioClip> roundLevelAudioClips = new();

    public List<AudioClip> CorrectPickUpSoundClips = new();

    public List<AudioClip> WrongPickUpSoundClips = new();

    //public AudioSource WarDrums = new();

    private AudioSource m_AudioSource; // reference to the audio source

    private AudioSource[] m_AllPlayingClips;


    private void Start()
    {
        // Reference to the Audio source
        m_AudioSource = GetComponent<AudioSource>();
    }

    ///// <summary>
    ///// Intial setup of Gauntlet Round One Music
    ///// </summary>
    //public void InitialiseRoundMusic()
    //{
    //    Debug.Log("Initialising Gauntlet Round Music");
    //    // Reference to the Audio source
    //    //m_AudioSource = GetComponent<AudioSource>();
    //    RoundOneDrums();
    //    Debug.Log("Gauntlet Music Setup, Background Music should have changed");
    //}

    ///// <summary>
    /////  Setup Audio for round one
    ///// </summary>
    //public void RoundOneDrums()
    //{
    //    //Debug.Log("Stopping all playing Audio");
    //    //StopStartBackGroundMusic();

    //    Debug.Log("All Music Should Stop and then...the drums should start next");
    //    PlayAudioClipsStart(roundLevelAudioClips);
    //}

    /// <summary>
    ///  play sound on correct pickup
    /// </summary>
    public void CorrectPickup()
    {
        PlayAudioClipsStart(CorrectPickUpSoundClips);
        Debug.Log("Correct Pickup Audio played");
    }

    /// <summary>
    /// Play a buzzer when pickup is Not Yours!
    /// </summary>
    public void WrongPickup()
    {
        PlayAudioClipsStart(WrongPickUpSoundClips);
        Debug.Log("Wrong Pickup Audio played");
    }

    /// <summary>
    /// Function to stop all other audio playing
    /// </summary>
    public void StopStartBackGroundMusic()
    {
        Debug.Log("Looking for all Audiosources");
        m_AllPlayingClips = FindObjectsOfType<AudioSource>();

        for (int i = 0; i < m_AllPlayingClips.Length; i++)
        {
            AudioSource currentClip = m_AllPlayingClips[i];
            Debug.Log("Check to see if clip is playing");
            // Check to see if current clip is playing
            if (currentClip.isPlaying == true)
            {
                Debug.Log("Found a clip that was playing");
                // if playing then stop
                currentClip.Stop();
                Debug.Log("Stopped all music!");
            }
        }
    }



    /// <summary>
    /// Takes in a List of audio clips and selects a random one and plays it
    /// </summary>
    /// <param name="audioClips"></param>
    private void PlayAudioClipsStart(List<AudioClip> audioClips)
    {
        m_AudioSource = GetComponent<AudioSource>();
        AudioClip clipToPlay = audioClips[Random.Range(0, audioClips.Count)];

        // Changes the pitch each time played - gives less sound fatigue
        m_AudioSource.pitch = Random.Range(0.1f, 0.2f);
        Debug.Log("Adjusted the pitch of the audio clip");
        m_AudioSource.PlayOneShot(clipToPlay);
        Debug.Log("Played the audio clip");
    }

}

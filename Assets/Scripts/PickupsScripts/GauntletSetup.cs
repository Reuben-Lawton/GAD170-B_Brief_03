using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GauntletSetup : MonoBehaviour
{
    public AudioClip gauntletDrums;

    private AudioSource m_AudioSource; // reference to the audio source

    public Transform gauntletStartingPoint;

    public Vector3 startingPoint;

    private GameObject spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        SetupMusic();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player_01") || other.tag.Equals("Player_02") || other.tag.Equals("BaseTank"))
        {
            // start the gauntlet music

            m_AudioSource.PlayOneShot(gauntletDrums);
        }

        // here invoke the pickups script 
    }

    private void SetupMusic()
    {
        m_AudioSource = GetComponent<AudioSource>();

    }

    private void GetStartingPoint()
    {
        spawnPoint = GetComponent<GameObject>();
        gauntletStartingPoint = spawnPoint.transform;
        startingPoint = gauntletStartingPoint.transform.position;
    }
}

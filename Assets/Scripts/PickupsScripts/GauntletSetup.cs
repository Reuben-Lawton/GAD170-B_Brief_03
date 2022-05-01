using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GauntletSetup : MonoBehaviour
{
    public AudioClip gauntletDrums;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player_01") || other.tag.Equals("Player_02") || other.tag.Equals("BaseTank"))
        {
            // start the gauntlet music


        }
    }

    private void SetupMusic()
    {
        gauntletDrums = GetComponent<AudioClip>();

    }
}

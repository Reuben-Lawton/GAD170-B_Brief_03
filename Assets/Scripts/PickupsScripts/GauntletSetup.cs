using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GauntletSetup : MonoBehaviour
{    
    public Vector3 gauntletStartingPoint;

    public UnityEvent startGauntlet = new();

    public Transform gauntletTriggerZone;

    private GameObject m_StartSpawnCube;

    
    private void OnEnable()
    {
        startGauntlet.AddListener(StartGauntletSetup);
        Debug.Log("Added the gauntlet setup to the gauntlet event");
    }

    private void OnDisable()
    {
        startGauntlet.RemoveListener(StartGauntletSetup);
        Debug.Log("Removed the gauntlet setup from the gauntlet event");
    }


    public void StartGauntletSetup()
    {

        GetStartingPoint();
        Debug.Log("Spawn point function complete");

        //SetupMusic();        
        startGauntlet?.Invoke();
        Debug.Log("Gauntlet Start Event Invoked");
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    // if (other.tag.Equals("Player_01") || other.tag.Equals("Player_02") || other.tag.Equals("BaseTank"))
    //    if (other.GetComponent<Rigidbody>())
    //    {
    //        Debug.Log("Detected one of the players or a tank entering the trigger zone");
    //        startGauntlet?.Invoke();
    //        Debug.Log("Gauntlet Event started!");
    //    }
    //}

    //private void SetupMusic()
    //{

    //    // start the gauntlet music
    //    audioSource = GetComponent<AudioSource>();
    //    Debug.Log("Setting Up Music");


    //    // play the gauntlet drums
    //    audioSource.PlayOneShot(gauntletDrums);
    //    Debug.Log("Playing the Drums");
    //}

    private void GetStartingPoint()
    {
        //spawnPoint = gameObject.transform.Find("GauntletSpawnPoint")
        //spawnPoint = GetComponentInChildren<GameObject>().Equals("GauntletSpawnPoint");

        // gauntletStartingPoint = transform.Find("GauntletSpawnPoint");

        m_StartSpawnCube = GameObject.FindGameObjectWithTag("GauntletSpawnPoint");
        Debug.Log("Found spawn point object");

        gauntletStartingPoint = m_StartSpawnCube.transform.position;
        Debug.Log("Set the spawn point to the objects Transform position");
    }
}

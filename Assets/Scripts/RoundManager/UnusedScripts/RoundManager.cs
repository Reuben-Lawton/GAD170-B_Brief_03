using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{
    public Pickups pickups;
    // Start is called before the first frame update
    void Start()
    {
        // startGeneration();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ResetGame()
    {
        // player.Reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //public void startGeneration()
    //{
    //    pickups = FindObjectOfType<Pickups>();
    //}
}

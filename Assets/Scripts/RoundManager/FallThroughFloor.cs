using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallThroughFloor : MonoBehaviour
{
    // Value used for the current scene
    private int currentScene;
    


    private void ResetLevel()
    {
        // get the current scene
        currentScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Current Scene is : " + currentScene);
        // reload the current scene

        SceneManager.LoadScene(currentScene);
        Debug.Log("Scene Restarted");

    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object fell into the void and as a result will now trigger a restart");
        ResetLevel();

        Debug.Log("The Level has been reset");
    }

}

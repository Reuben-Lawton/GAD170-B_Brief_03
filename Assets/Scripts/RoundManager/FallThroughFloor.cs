using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallThroughFloor : MonoBehaviour
{
    private int currentScene;
    


    private void ResetLevel()
    {
        // get the current scene
        currentScene = SceneManager.GetActiveScene().buildIndex;

        // reload the current scene

        SceneManager.LoadScene(currentScene);

    }


    private void OnTriggerEnter(Collider other)
    {
        ResetLevel();
    }

}

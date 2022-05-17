using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class WeaponsDamage : MonoBehaviour
{
    public float forceApplied = 50f;
    public float damageDone = 0.2f;
    public int hitsTaken = 0;
    public List<int> howManyHitsList = new();
    public int hitsCriticalLimit = 10;

    public UnityEvent tankHitWeaponEvent;

    private int currentScene = 1;

    // private Coroutine m_restartLevelRoutine;


    private void OnCollisionEnter(Collision collision)
    {
        collision.rigidbody.AddForce(Vector3.back * forceApplied);

        // Invoke the Tank hitting a Weapon Event
        tankHitWeaponEvent?.Invoke();
    }

    /// <summary>
    /// Calculating how many hits have been taken
    /// </summary>
    public void CalculateHits()
    {
        for (int i = 0; i < hitsCriticalLimit; i++)
        {
            hitsTaken += 1;
            Debug.Log("Tank took another hit! \n Currently the Total Hits taken is : " + hitsTaken + "!");
        }
    }

    /// <summary>
    /// Adding the hits taken to a Hit List
    /// </summary>
    public void AddHitToList()
    {
        for (int i = 0; i <=hitsCriticalLimit; i++)
        {
            if (hitsTaken == 1)
            {
                howManyHitsList.Add(1);
                Debug.Log("Add 1 Hit to the Hit list");
            }
            else if (hitsTaken > 1 && hitsTaken < hitsCriticalLimit)
            {
                howManyHitsList.Add(1);
                Debug.Log("Adding 1 More Hit to the Hit list");
            }
        }
    }

    /// <summary>
    /// Once Critical Hit Limit has been reached then reset the level
    /// </summary>
    public void CriticalHitAction()
    {
        if (hitsTaken == hitsCriticalLimit)
        {
            Debug.Log("Your Dead, reseting the level");
        }

        // Start the restart current scene routine
        StartCoroutine(RestartCurrentScene());
    }

    /// <summary>
    ///     
    /// </summary>
    /// 

    private IEnumerator RestartCurrentScene()
    {
        Debug.Log("Player taken 10 Hits");
        // wait 1 second
        yield return 1;
        // then restart the scene
        SceneManager.LoadScene(currentScene);
        Debug.Log("Restarting current scene");

        Debug.Log("Will I need to also reset all lists of pickups collected ??");
        yield return null;
    }
   
}

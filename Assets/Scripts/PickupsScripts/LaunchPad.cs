using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : MonoBehaviour
{
    private Rigidbody currentTriggeringObject;

    private float m_LaunchForce;

    //private float m_LaunchSpeed = 300f;

    private List<Vector3> m_pickDirectionToLaunch = new();

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        m_LaunchForce = AddRandomLaunchForce();

        currentTriggeringObject = other.GetComponent<Rigidbody>();
        Debug.Log("Reference to colliding object is set");

        Vector3 randomlyPickedDirection = AddDirectionsToLaunch();

        currentTriggeringObject.AddForce(randomlyPickedDirection * m_LaunchForce);
        Debug.Log("Have added a force of 500 in the up direction");

        //currentTriggeringObject.AddForce(Vector3.forward * m_LaunchSpeed);
        //Debug.Log("Have launched forward with a force of 300");


    }

    //private void OnTriggerStay(Collider other)
    //{
    //    currentTriggeringObject = other.GetComponent<Rigidbody>();
    //    Debug.Log("Reference to colliding object is set");

    //    Vector3 launchVector = AddDirectionsToLaunch();
    //    currentTriggeringObject.AddForce(launchVector * m_LaunchForce);
    //    Debug.Log("Have added a force of 500 in the up direction");
    //}

    private Vector3 AddDirectionsToLaunch()
    {
        m_pickDirectionToLaunch.Add(Vector3.up);
        m_pickDirectionToLaunch.Add(Vector3.back);
        m_pickDirectionToLaunch.Add(Vector3.forward);
        m_pickDirectionToLaunch.Add(Vector3.left);
        m_pickDirectionToLaunch.Add(Vector3.right);

        int vRandom = Random.Range(0, 5);
        var randomPick = vRandom;
        Vector3 randomDirection = m_pickDirectionToLaunch[randomPick];

        //for (int i = 0; i < m_pickDirectionToLaunch.Count; i++)
        //{
        //    randomDirection = Random.Range(m_pickDirectionToLaunch(0), m_pickDirectionToLaunch.Count)))
        //}

        return randomDirection;
    }

    private float AddRandomLaunchForce()
    {        
        float randomForceAmount = Random.Range(100, 500);

        return randomForceAmount;
    }



}

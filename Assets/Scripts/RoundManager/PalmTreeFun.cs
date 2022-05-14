using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalmTreeFun : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}


public class PalmTreeSpec
{
    public float launchSpeed;
    public float distanceToTravel;
    public Vector3 directionToMove;
       
}
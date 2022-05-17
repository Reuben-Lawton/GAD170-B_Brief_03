using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WarpBackToStart : MonoBehaviour
{
    private GameObject currentTank;

    public Transform reSpawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        currentTank = other.gameObject;
        Debug.Log("How did you end up here ??");

        currentTank.transform.position = reSpawnPoint.position;
        Debug.Log("Lost tank is returned to spawn point");
    }


}

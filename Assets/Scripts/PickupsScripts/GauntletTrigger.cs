using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GauntletTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent gauntletTriggerInitialization;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object has entered the Trigger Zone");
        if (other.GetComponent<Rigidbody>())
        {
            // Start the Gauntlet Event
            gauntletTriggerInitialization?.Invoke();
            Debug.Log("Gauntlet Triggered, Event Invoked");
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TempTrialEvent : MonoBehaviour
{

    public UnityEvent tempTestEvent = new();

    public UnityEvent secondTestEvent = new();

    public UnityEvent pickupTriggerEvent = new(); //Event for when Correct pickup

    private void OnEnable()
    {
        tempTestEvent.AddListener(NameDisplay);

        secondTestEvent.AddListener(TestDisplay);
    }


    private void OnDisable()
    {
        tempTestEvent.RemoveListener(NameDisplay);

        secondTestEvent.RemoveListener(TestDisplay);

    }


    public void NameDisplay()
    {
        Debug.Log("Here is your test message");
    }

    public void TestDisplay()
    {
        Debug.Log("Second Test Message");
    }

}

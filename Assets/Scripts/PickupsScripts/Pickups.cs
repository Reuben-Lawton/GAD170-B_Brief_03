using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pickups : MonoBehaviour
{
    [Header("In Game Pickups")]
    //[SerializeField]
    //public GameObject PickupZoneOne;
    //public GameObject PickupZoneTwo;
    private Tank playerTank;

    public Transform Pickup;

    //public GameObject SingleAmmo;
    //public GameObject TwentyPackAmmo;
    //public GameObject ShieldTwentyPercent;

    [Header("Ammo, Shield, Repair Kit Count")]
    private float m_maxBonusShield = 2.5f;
    private int m_maxAmmo = 30;



    // Start is called before the first frame update
    void Start()
    {
        playerTank = FindObjectOfType<Tank>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //public void AddShield(float shieldValueAmount)
    //{
    //    Debug.Log("Will be adding an event to activate");


    //}

    //private void DoShieldIncrease()
    //{

    //}

    private void GetObjects()
    {
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollecting : MonoBehaviour
{       
    #region Classes and Variables
    [Header ("Lists")]

    public List<int> tankStorageGreen = new();

    public List<int> tankStorageRed = new();

    [Header("List Variables")]

    public int fullTank = 6; // Amount of Storage that is enough 

    [Header("Action Variables")]

    public float forceApplied = 500; // Force applied when we hit something

    public float forceAmountUp = 200; // A force amount 

    private Rigidbody CollidingTankRigidBody; // reference to the rigidbody

    [Header("Events")]

    public UnityEvent pickupTriggerEvent = new(); //Event for when Correct pickup

    public UnityEvent wrongPickupTriggerEvent = new(); // Event for when Wrong pickup

    [Header("Event Variables")]

    public bool isTank;

    public bool IsCorrectPickup = false; // Set if is correct pickup or not

    public bool IsGreenAction = false; // Set action will be for Green

    public bool IsRedAction = false; // Set action will be for Red

    public bool StorageToIncrease = false; // Set Storage increase option 

    private GameObject thisPickup;

    private GameObject theCurrentTank;

    #endregion

    #region defunct code that is here for legacy and to look back on in future

    // private List<TankStorage> currentList; 

    // public StorageList listOfStorageLists = new();

    // private TankStorage tankStorage;

    #endregion

    #region Enable and Disable event inclusions
    /// <summary>
    /// Sets up the functions to run with the correct and wrong pick trigger events
    /// </summary>
    private void OnEnable()
    {
        #region defunct code that is here for legacy and to look back on in future

        //PickupTriggerEvent.AddListener(() => { AddPickupToList(tankStorageGreen); });

        // WrongPickupTriggerEvent.AddListener(InitialiseCollecting);
        #endregion


        #region Enable the Add Pickups using WrongPickupTriggerEvent
        // Add the Pickup Add to List function to the Event
        pickupTriggerEvent.AddListener(AddToPickUpList);

        #endregion

        #region Reset the Check List using WrongPickupTriggerEvent  Don't think I need this  ??
        // Add a reset to the List of Checks
        // pickupTriggerEvent.AddListener(ResetListToUse);
        #endregion

        #region Enable Event Actions using WrongPickupTriggerEvent

        // Add a Repel Action to the Wrong Event
        wrongPickupTriggerEvent.AddListener(AddForceToWrong);        

        // Removing the Extra Wrong Action, that had used a temporary function
        pickupTriggerEvent.AddListener(() => { RepelWrongTank(forceAmountUp); });

        #endregion

        #region Reset the Check List using WrongPickupTriggerEvent
        // Add a reset to the List of Checks
        wrongPickupTriggerEvent.AddListener(ResetListToUse);
        #endregion
    }

    /// <summary>
    /// removes the functions to run with the correct and wrong pick trigger events
    /// </summary>
    private void OnDisable()
    {
        #region defunct code that is here for legacy and to look back on in future

        // attempted to use a list of lists then pass in a list that i want but kept getting stuck

        // PickupTriggerEvent.AddListener(() => { AddPickupToList(GetReturnListToUse); });

        //PickupTriggerEvent.AddListener)

        // Removes the initial collecting setup
        //WrongPickupTriggerEvent.RemoveListener(InitialiseCollecting);
        #endregion


        #region Remove Add Pick to Pick Up List from PickupTriggerEvent
        // Removes the add pickup from event
        pickupTriggerEvent.RemoveListener(AddToPickUpList);
        #endregion

        #region Remove Reset from PickupTriggerEvent Don't think I need this  ??
        // Remove the Reset
        // pickupTriggerEvent.AddListener(ResetListToUse);
        #endregion

        #region Disable Actions for WrongPickupTriggerEvent
        // Remove the add force to wrong player
        wrongPickupTriggerEvent.AddListener(AddForceToWrong);

        // Removing the Extra Wrong Action, that had used a temporary function
        pickupTriggerEvent.RemoveListener(() => { RepelWrongTank(forceAmountUp); });
        #endregion

        #region Remove Reset from WrongPickupTriggerEvent
        // Remove the Reset
        wrongPickupTriggerEvent.RemoveListener(ResetListToUse);
        #endregion

    }

    #endregion

    /// <summary>
    /// Get a reference to the colliding objects rigidbody
    /// </summary>
    /// <param name="collision"></param>
    //private void InitialiseRigidbodyToRepel()
    //{
    //    Debug.Log("Checkin to see and Getting a refernce to the collding object's rididbody");

    //    // check to see if colliding object has a rididbody to use 
    //    // then getting a reference to 

    //    //GameObject currentPickUpToCheckForRigidbody;
    //    //// rigid = GetComponent<Rigidbody>();

    //    //currentPickUpToCheckForRigidbody = GetComponent<GameObject>();

    //    //currentPickUpToCheckForRigidbody.transform.rigid
        

    //    //if (Collision != null)
    //    //{
    //    //    rigid = GetComponent<Rigidbody>();
    //    //    Debug.Log("the collding object had a rididbody and now a reference has been set");
    //    //}
    //    //else
    //    //{
    //    //    Debug.Log("no rididbody found! no actions taken!");
    //    //    return;
    //    //}

    //    #region defunct code that is here for legacy and to look back on in future

    //    // arrayList.AddRange(tankStorageGreen, tankStorageRed);
    //    #endregion

    //}

    

    #region defunct code that is here for legacy and to look back on in future

    //private void AddPickupToList()
    //{
    //    //if (IsCorrectPickup == true)
    //    //{

    //    //    listToIncrease.Add(1);
    //    //}

    //    // listToIncrease(listOfStorageLists.Count[0]

    //}
    #endregion

    #region Setting up the collider

    /// <summary>
    /// Collision Setup for Pick Up Objects
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {       
        theCurrentTank = collision.gameObject;
        //Debug.Log("The current tank has been set!");

        string tankName = theCurrentTank.name;
        //Debug.Log("The current tanks name is : " + tankName);


        if (tankName != "Player_One(Clone)" || tankName != "Player_Two(Clone)")
        {
            isTank = false;
            return;
        }
        else if (tankName == "Player_One(Clone)" || tankName == "Player_Two(Clone)")
        {
            isTank = true;
        }


        //if (collision.gameObject.name != "Player_One(Clone)" || collision.gameObject.name != "Player_Two(Clone)")
        //{
        //    return;
        //}
        //else if
            
        if(isTank == true)
        {           
                        
            Debug.Log("Collision Detected, now to see if it was either tank before doing anything else");

            Debug.Log("If it was either tank colliding then do this");
            //thisPickup = GetComponent<GameObject>();                        

            // Set a reference to the current pickup object
            thisPickup = gameObject;
            Debug.Log("The Current pickup has a tag called : " + thisPickup.tag);
            Debug.Log("The current pickup is called : " + thisPickup.name);

            // Check if the collision Was Player One
            if (collision.gameObject.name == "Player_One(Clone)")
            {
                Debug.Log("Player One has Collided with the pickup");

                // Check if the current pickup has a tag GreenPickup
                if (thisPickup.CompareTag("GreenPickup"))
                {
                    IsCorrectPickup = true; // Set to correct pickup
                    IsGreenAction = true; // Set to Green Action
                    StorageToIncrease = true; // Storage is Set now to increase
                    Debug.Log("Set Correct Pickup and Set to Green");

                    // Invoke the event
                    pickupTriggerEvent?.Invoke();
                    Debug.Log("Pickup correct Event Triggered");

                    // Attach the correct pickup to the tank
                    AttachPickup(thisPickup, theCurrentTank);
                }
                // Check if current pickup is Red and then apply wrong actions
                else if (thisPickup.CompareTag("RedPickup"))
                {
                    IsCorrectPickup = false; // Set to wrong Pickup
                    IsRedAction = true; // Set Action to occur on Red Tank
                    StorageToIncrease = false; // No Increase to storage

                    // Get a reference for the colliding tanks rigidbody

                    if (theCurrentTank.GetComponent<Rigidbody>() != null)
                    {
                        CollidingTankRigidBody = theCurrentTank.GetComponent<Rigidbody>();
                    }

                    //Invoke the wrong player event
                    wrongPickupTriggerEvent?.Invoke();
                    Debug.Log("Wrong Pickup Event Triggered for Green Tank");
                }

            }
            /// <summary>
            /// Actions for when Player Two collides with the Pickups
            /// </summary>
            else if (collision.gameObject.name == "Player_Two(Clone)")
            {
                Debug.Log("Player Two has Collided with the pickup");

                // Check if the current pickup has a tag RedPickup
                if (thisPickup.CompareTag("RedPickup"))
                {
                    IsCorrectPickup = true; // Set to correct pickup
                    IsRedAction = true; // Set Red Action to True
                    StorageToIncrease = true; // Storage is Set now to increase
                    Debug.Log("Set Correct Pickup and Set to Red");

                    // Invoke the event
                    pickupTriggerEvent?.Invoke();
                    Debug.Log("Pickup correct Event Triggered");

                    // Attach the correct pickup to the tank
                    AttachPickup(thisPickup, theCurrentTank);
                }
                // Check if current pickup is Green and then apply wrong actions
                else if (thisPickup.CompareTag("GreenPickup"))
                {
                    IsCorrectPickup = false; // Set Wrong Pickup
                    IsGreenAction = true;  // Set Action to occur on Green Tank
                    StorageToIncrease = false; // No Increase in storage 

                    // Get a reference for the colliding tanks rigidbody

                    if (theCurrentTank.GetComponent<Rigidbody>() != null)
                    {
                        CollidingTankRigidBody = theCurrentTank.GetComponent<Rigidbody>();
                    }

                    //Invoke the wrong player event
                    wrongPickupTriggerEvent?.Invoke();
                    Debug.Log("Wrong Pickup Event Triggered for Red Tank");
                }

            }
            // reset the is tank to false
            isTank = false;
        }
        else
        {
            return;
        }
               
        
        
    }

    #endregion

    #region defunct code that is here for legacy and to look back on in future

    //public List<TankStorage> GetReturnListToUse()
    //{
    //    if (IsGreen == true && StorageToIncrease == true)
    //    {
    //        //var listToAddTo = listOfStorageLists.tankStorageList[0].tankStorageGreen;

    //        //int v = tankStorage[0];

    //        // Return the Green List
    //        currentList = listOfStorageLists.tankStorageGreen;
    //        return currentList;
    //    }
    //    else if (IsRed == true && StorageToIncrease == true)
    //    {
    //        // Return the Red List
    //        currentList = listOfStorageLists.tankStorageRed;
    //        return currentList;
    //    }
    //    else
    //    {
    //        return null;
    //    }
    //}

    #endregion

    #region Actions For Wrong Object Collided applied to Tank
    /// <summary>
    /// When a Tank triggers the Wrong capsule
    /// add a force to repel them back
    /// </summary>
    /// <param name="amount"></param>
    public void RepelWrongTank(float amount)
    {
        Debug.Log("Wrong Pickup!");

        // Add a back force to the wrong tank
        CollidingTankRigidBody.AddForce(Vector3.back * amount);
        Debug.Log("You Went Back!");
    }


    /// <summary>
    /// Additional Wrong Force just because
    /// </summary>
    private void AddForceToWrong()
    {
        // Add a force back to the tank that hit the wrong pickup
        CollidingTankRigidBody.AddForce(Vector3.back * forceApplied);
        Debug.Log("Applied a repeling Force, Player hit the wrong Pickup");
    }

    #endregion

    /// <summary>
    /// Add 1 Point to the Players List
    /// </summary>
    public void AddToPickUpList()
    {
        Debug.Log("Starting Add to Pickup Lists");
        // Check if both green and increase is true
        if (IsGreenAction == true && StorageToIncrease == true)
        {
            // Add 1 Point to the Green Tank 
            tankStorageGreen.Add(1);
            Debug.Log("Green Tank Pickup, Add 1 point");
        }
        // Check if both red and increase is true
        else if (IsRedAction == true && StorageToIncrease == true)
        {
            // Add 1 Point to the Red Tank
            tankStorageRed.Add(1);
            Debug.Log("Red Tank Pickup, Add 1 point");
        }
        else
        {
            Debug.Log("Do nothing");            
        }
    }

    /// <summary>
    /// Reset all list Checks
    /// </summary>
    private void ResetListToUse()
    {
        IsCorrectPickup = false; // Reset Correct Pickup
        IsGreenAction = false; // Reset Green Action
        IsRedAction = false; // Reset Red Action
    }

    /// <summary>
    ///  Attach the pickup to the correct colliding tank
    /// </summary>
    /// <param name="theHitPickup"></param>
    /// <param name="theTank"></param>
    public void AttachPickup(GameObject theHitPickup, GameObject theTank)
    {
        Vector3 onTopOfTank = new(0, 1.5f, 0);
        Vector3 moveUp = new(0, 1, 0);
        Debug.Log("Attempting to attach the pickup object to the tank");
        // make the current pickup parent to the current tank
        theHitPickup.transform.parent.position = theTank.transform.position + onTopOfTank;
        Debug.Log("The pickup position should now match the tanks position");
        Collider currentPickupCollider = theHitPickup.GetComponent<Collider>();

        onTopOfTank += moveUp;
        Debug.Log("Moving the next pickup : " + onTopOfTank);

        // if the pickup has a collider
        if (currentPickupCollider != null)
        {
            Debug.Log("Attempting to turn of the pickups collider for now");
            // then disable the collider for now
            currentPickupCollider.enabled = false;
            Debug.Log("Should have now disabled the collider");
        }


    }

}

#region defunct code that is here for legacy and to look back on in future

//public List<int> tankStorageGreen = new();
//public List<int> tankStorageRed = new();

//[System.Serializable]
//public class TankStorage
//{
//    public List<int> tankStorageGreen;

//    public List<int> tankStorageRed;
//}

//[System.Serializable]
//public class StorageList
//{
//    public List<TankStorage> tankStorageList;
//    internal List<TankStorage> tankStorageGreen;
//    internal List<TankStorage> tankStorageRed;
//}
#endregion

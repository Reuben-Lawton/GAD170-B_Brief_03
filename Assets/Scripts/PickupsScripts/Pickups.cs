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
    //private Tank playerTank;

    public GameObject GreenPickupPrefab;

    public GameObject RedPickupPrefab;

    private bool greenSetup = false;
    private bool redSetup = false;

    private GauntletSetup gauntletSetup;

    private int currentPickup = 0;

    // Green Pickups List
    public List<GameObject> greenPickups = new(); // A list to hold all of the green pickups that are spawned in

    // Red Pickups List
    public List<GameObject> redPickups = new(); // A list to hold all of the green pickups that are spawned in

    public int pickupCount = 8;

    public Vector3 startPosition;

    public Transform roundOnePickupStart;

    //private Vector3 objectPoolPosition = new(30, 35, 30); //   A new Vector3 somewhere off screen
    private Vector3 objectPoolPosition = new(1, 1, 1); //   A new Vector3 somewhere off screen
                                                            //public List< GreenPickupList = new();

    //public GameObject SingleAmmo;
    //public GameObject TwentyPackAmmo;
    //public GameObject ShieldTwentyPercent;

    // [Header("Ammo, Shield, Repair Kit Count")]
    // private float m_maxBonusShield = 2.5f;
    // private int m_maxAmmo = 30;

    //private HingeJoint hingeJoint;

    // Start is called before the first frame update
    public void StartSpawnPickups()
    {
        RoundOneStartPosition();
        GetObjects();
        Initialise();
    }

    //public void AddShield(float shieldValueAmount)
    //{
    //    Debug.Log("Will be adding an event to activate");


    //}

    //private void DoShieldIncrease()
    //{

    //}

    private void Initialise()
    {
        Debug.Log("Initialisation of Instantiation called");
        // roundOnePickupStart = GetComponentInParent<Transform>();
        roundOnePickupStart = GameObject.FindGameObjectWithTag("GauntletSpawnPoint").transform;

        Quaternion spawnPointRotation = roundOnePickupStart.localRotation;

       if(greenSetup != true)
        {            
            for (int i = 0; i <= pickupCount; i++)
            {
                // Spawns in the GREEN token
                GameObject CloneGreenToken = Instantiate(GreenPickupPrefab, objectPoolPosition, spawnPointRotation);
                int currentTank = i;
                Debug.Log("Spawned a GREEN Clone number " + currentTank);

                // Adds the instantiated GREEN Token to the Green pickups list
                greenPickups.Add(CloneGreenToken);

                // Set the tag of current GREEN Clone
                CloneGreenToken.name = "GreenClone_" + currentTank; 
                Debug.Log("Spawned clone tag is set as : " + CloneGreenToken.tag);
            }
            SpawnPickups(greenPickups);

            greenSetup = true;
            Debug.Log("Green Setup True");
        }

        if (redSetup != true)
        {

            for (int i = 0; i <= pickupCount; i++)
            {
                // Spawns in the RED tokens
                GameObject CloneRedToken = Instantiate(RedPickupPrefab, objectPoolPosition, spawnPointRotation);
                int currentREDClone = i;
                Debug.Log("Spawned a RED Clone number " + currentREDClone);

                // Adds the instantiated RED Token to the Red pickups list
                redPickups.Add(CloneRedToken);
                Debug.Log("Added the RED Clone to the Red Clone List");

                // Set the tag of current RED Clone
                CloneRedToken.name = "RedClone_" + currentREDClone;
                Debug.Log("Spawned clone tag is set as : " + CloneRedToken.tag);
            }
            SpawnPickups(redPickups);

            redSetup = true;
            Debug.Log("Red Setup True");
        }        

    }
    /// <summary>
    /// Setup the positions of the Red & Green Clones
    /// </summary>
    /// <param name="listName"></param>
    private void SpawnPickups(List<GameObject> listName) 
    {
        Debug.Log("Spawning Pickups for Gauntlet");
        Vector3 nextPosition;
        // If a RED pickup set the Z position across 20
        if (listName == redPickups)
        {
            
            // startPosition += new Vector3(10, 0, -20);  - Red overlapping green
            startPosition += new Vector3(18, 0, -40);
            Debug.Log("For the RED clones the spawn starting point has been updated :" + startPosition);

            for (int i = 0; i < listName.Count; i++)
            {
                Debug.Log("GREEN Pickups Spawning Now");
                // temporary value for the currently spawned pickup
                currentPickup = i;
                if (currentPickup == 0)
                {
                    listName[currentPickup].transform.position = startPosition;
                    Debug.Log("Set up the First GREEN Pickup Clone");
                }
                else if (currentPickup != 0)
                {
                    // the last spawn now is i -1 
                    int lastSpot = i - 1;
                    // gets the last spawn point used
                    Vector3 lastPlacement = listName[lastSpot].transform.position;
                    Debug.Log("The last GREEN spawned position was : " + lastPlacement);
                    // moves the next spawn point forward 5
                    nextPosition = lastPlacement + new Vector3(0, 0, 5);
                    Debug.Log("The next GREEN position to spawn at will be : " + nextPosition);
                    listName[currentPickup].transform.position = nextPosition;
                    Debug.Log("The GREEN clone has spawned to the new position");
                }

            }
        }
        else if (listName == greenPickups)
        {
            Debug.Log("RED Pickups Spawning Now");
            for (int i = 0; i < listName.Count; i++)
            {

                currentPickup = i;
                if (currentPickup == 0)
                {
                    listName[currentPickup].transform.position = startPosition;
                    Debug.Log("Set up the First RED Pickup Clone");
                }
                else if (currentPickup != 0)
                {
                    int lastSpot = i - 1;
                    Vector3 lastPlacement = listName[lastSpot].transform.position;
                    Debug.Log("The last RED spawned position was : " + lastPlacement);
                    nextPosition = lastPlacement + new Vector3(0, 0, -5);
                    Debug.Log("The next RED position to spawn at will be : " + nextPosition);
                    listName[currentPickup].transform.position = nextPosition;
                    Debug.Log("The RED clone has spawned to the new position");
                    // nextPosition += new Vector3(3, 0, 0);
                }

            }
        }
    }

    public void RoundOneStartPosition()
    {
        gauntletSetup = FindObjectOfType<GauntletSetup>();
        // Sets the starting point for where the pickups are spawned from 

        
        // Vector3 anUpStart = new(12, 26, -10); Green overlapping Red
        Vector3 anUpStart = new(8, 26, -10);
        startPosition = gauntletSetup.gauntletStartingPoint + anUpStart;
    }


    private void GetObjects()
    {
        // reference to the green and red prefab ojbects
        // GreenPickupPrefab = GameObject.FindGameObjectWithTag("GreenPickup");
        // RedPickupPrefab = GameObject.FindGameObjectWithTag("RedPickup");

        Debug.Log("Get the prefab objects - ??");
    }




    //private void OnCollisionEnter(Collision collision) {
    //    //{
    //    //    if(collision.transform.tag == "Player_One")
    //    //    {
    //    //        AddPickupToTail();
    //    //    }



    //        //if (collision.gameObject.tag == "this")
    //        //{
    //        //    var hj : HingeJoint;
    //        //    hj = gameObject.AddComponent("HingeJoint");
    //        //    hingeJoint.connectedBody = other.rigidbody;
    //        //    rigidbody.mass = 0.00001;
    //        //    collider.material.bounciness = 0;
    //        //    rigidbody.freezeRotation = true;
    //        //    rigidbody.velocity = Vector3(0, 0, 0);
    //        //}


    //}

    //private void OnCollisionEnter(Collision collision)
    //{

    //}

    //private void InitialSetup()
    //{
    //    playerTank = FindObjectOfType<Tank>();
    //    GreenPickup = FindObjectOfType<GameObject>();


    //    //hingeJoint = FindObjectOfType<HingeJoint>();
    //}

    //private void AddPickupToTail()
    //{


    //    GreenPickup.transform.position = new Vector3(playerTank.transform.position.x + 2, playerTank.transform.position.y + 2, playerTank.transform.position.z + 2);
    //}
}

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

    public GameObject GreenPickupPrefab;

    public GameObject RedPickupPrefab;

    private bool greenSetup = false;
    private bool redSetup = false;

    public int pickupCount = 6;

    private int currentPickup = 0;

    // Green Pickups List
    private List<GameObject> greenPickups = new List<GameObject>(); // A list to hold all of the green pickups that are spawned in

    // Red Pickups List
    private List<GameObject> redPickups = new List<GameObject>(); // A list to hold all of the green pickups that are spawned in

    public Vector3 startPosition;

    public Transform roundOnePickupStart;

    private Vector3 objectPoolPosition = new (-1000, -1000, -1000); //   A new Vector3 somewhere off screen
        //public List< GreenPickupList = new();

    //public GameObject SingleAmmo;
    //public GameObject TwentyPackAmmo;
    //public GameObject ShieldTwentyPercent;

    // [Header("Ammo, Shield, Repair Kit Count")]
    // private float m_maxBonusShield = 2.5f;
    // private int m_maxAmmo = 30;

    //private HingeJoint hingeJoint;

    // Start is called before the first frame update
    void Start()
    {
        RoundOneStartPosition();
        //GetObjects();
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
       if(greenSetup != true)
        {
            for (int i = 0; i < pickupCount; i++)
            {
                // Spawns in the green token
                GameObject greenToken = Instantiate(GreenPickupPrefab, objectPoolPosition, transform.localRotation);

                // Adds the spawned object(column) to the columns List
                greenPickups.Add(greenToken);
            }
            SpawnPickups(greenPickups);

            greenSetup = true;
        }
        
       if (redSetup != true)
        {

            for (int i = 0; i < pickupCount; i++)
            {
                // Spawns in the red tokens
                GameObject redToken = Instantiate(RedPickupPrefab, objectPoolPosition, transform.localRotation);

                // Adds the spawned object(column) to the columns List
                redPickups.Add(redToken);
            }
            SpawnPickups(redPickups);

            redSetup = true;
        }

        

    }


    private void SpawnPickups(List<GameObject> listName) 
    {
        Vector3 nextPosition;
        // If a red pickup set the Z position across 20
        if (listName == redPickups)
        {
            startPosition += new Vector3(0, 0, -10);

            for (int i = 0; i < listName.Count -1; i++)
            {

                currentPickup = i;
                if (currentPickup == 0)
                {
                    listName[currentPickup].transform.position = startPosition;
                }
                else
                {
                    int lastSpot = i - 1;
                    Vector3 lastPlacement = listName[lastSpot].transform.position;
                    nextPosition = lastPlacement + new Vector3(5, 0, 0);

                    listName[currentPickup].transform.position = nextPosition;

                   // nextPosition += new Vector3(3, 0, 0);
                }

            }
        }
        else if (listName == greenPickups)
        {
            for (int i = 0; i < listName.Count -1; i++)
            {

                currentPickup = i;
                if (currentPickup == 0)
                {
                    listName[currentPickup].transform.position = startPosition;
                }
                else
                {
                    int lastSpot = i - 1;
                    Vector3 lastPlacement = listName[lastSpot].transform.position;
                    nextPosition = lastPlacement + new Vector3(5, 0, 0);

                    listName[currentPickup].transform.position = nextPosition;

                    // nextPosition += new Vector3(3, 0, 0);
                }

            }
        }


        


    }

    private void RoundOneStartPosition()
    {
        // Sets the starting point for where the pickups are spawned from 
        // startPosition = roundOnePickupStart.position;

        startPosition = new(15, 26, 5f);
    }

    //private void GetObjects()
    //{        
    //    // reference to the green and red prefab ojbects
    //    GreenPickupPrefab = GameObject.FindGameObjectWithTag("GreenPickup");
    //    RedPickupPrefab = GameObject.FindGameObjectWithTag("RedPickup");        
    //}




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

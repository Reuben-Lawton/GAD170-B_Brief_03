using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraterResetScript : MonoBehaviour
{
    public Vector3 redBonusSpawnSite; // new Vector3(-45, -25, 0.68f);  instead of having the numbers I'm going take the position reference from the crater and add 1 to Y

    public Vector3 greenBonusSpawnSite;


    public Transform greenCraterTransform;

    public Transform redCraterTransform;

    public Tank tankScript;

    public List<GameObject> collectedPickups = new();

    // Start is called before the first frame update
    void Start()
    {
        InitialBonusSpawnSiteSetup();

    }

    //public void onTrggerEnter(Collider collider)
    //{

    //}


    public void OnTriggerEnter(Collider redOther)
    {
        // Reset the count of collected objects to zero
        if (redOther.transform.tag == "Player")
        {

        }
    }


    //public void OnCollisionEnter(Collision collision)
    //{
    //    // If the player goes to the wrong side the object will not be able to collect
    //}


    private void InitialBonusSpawnSiteSetup()
    {
        // getting references to the GREEN crater objects 
        //greenCraterTransform = FindObjectOfType<Transform>();
        greenCraterTransform = GameObject.FindGameObjectWithTag("GreenCrater").transform;

        // creating a new position to use to spawn in objects at the GREEN bonus spawn site
        greenBonusSpawnSite = greenCraterTransform.position + new Vector3(0, 1, 0);


        // getting references to the RED crater objects 
        redCraterTransform = GameObject.FindGameObjectWithTag("RedCrater").transform;

        // creating a new position to use to spawn in objects at the RED bonus spawn site
        redBonusSpawnSite = redCraterTransform.position + new Vector3(0, 1, 0);

        tankScript = FindObjectOfType<Tank>();

        
        
    }
}

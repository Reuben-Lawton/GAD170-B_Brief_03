using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    private GameObject m_collidingTank;
    private Transform m_thisTanksTransform;
    private bool m_isCorrectPortal;

    private PlayerNumber m_CurrentPlayerNumber;
    private Color m_PlayerColour;
    private Transform m_VortexTransform;

    public Transform[] PlayerBaseLocation;

    private Transform m_playersBase;

    public Transform penaltyWarpReturnToStart;

    // Start is called before the first frame update
    void Start()
    {
      
    }



    private void OnTriggerEnter(Collider other)
    {
        // reference to the colliding tank
        m_collidingTank = other.gameObject;
        
        // check if the object has a rigidbody

        if (m_collidingTank.GetComponent<Rigidbody>() != null)
        {
            // reference to its transform so it can be warped
            m_thisTanksTransform = m_collidingTank.GetComponent<Transform>();
            Debug.Log("Have a reference to the tank that is trying to warp");
        }

        // check which player is trying to enter
        if (other.GetComponent<PlayerNumber>() == PlayerNumber.One)
        {
            // Player one is set to green
            m_CurrentPlayerNumber = PlayerNumber.One;
            m_PlayerColour = Color.green;
            Debug.Log("It is the Green tank attempting to enter");
        }
        else if (other.GetComponent<PlayerNumber>() == PlayerNumber.Two)
        {
            // player two is set to red
            m_CurrentPlayerNumber = PlayerNumber.Two;
            m_PlayerColour = Color.red;
            Debug.Log("It is the Red tank attempting to enter");
        }

    }

    /// <summary>
    /// Taking in the current tank and a base location to warp to
    /// </summary>
    /// <param name="tankToWarp"></param>
    /// <param name="baseLocation"></param>
    public void TeleportToBase(Transform tankToWarp, Vector3 baseLocation)
    {
        if ( m_isCorrectPortal == true)
        {
            tankToWarp.position = baseLocation;
        }
        else if (m_isCorrectPortal == false)
        {
            m_collidingTank.transform.position = penaltyWarpReturnToStart.position;
        }
    }

    /// <summary>
    ///  Getting the base locations
    /// </summary>
    /// <returns></returns>
    public Transform BaseLocations()
    {
        if (m_PlayerColour == Color.red)
        {
            m_playersBase = PlayerBaseLocation[0];
            return m_playersBase;
        }
        else if (m_PlayerColour == Color.green)
        {          
            m_playersBase = PlayerBaseLocation[1];
            return m_playersBase;
        }
        else
        {
            return penaltyWarpReturnToStart;
        }
    }

    public void PenaltyWarp()
    {
        if (m_isCorrectPortal == false)
        {
            m_collidingTank.transform.position = penaltyWarpReturnToStart.position;
        }
    }
    /// <summary>
    /// Checking to see if the correct tank is trying to get into the correct portal
    /// </summary>
    private void CheckCorrectTankAndPortal()
    {
        // getting a reference to the vortex transform
        if (GetComponent<Transform>() != null)
        {
            m_VortexTransform = GetComponent<Transform>();
        }

        ///<summary>
        /// Check if Warp is called green warp zone then check which player has tried to enter
        /// </summary>
        if (m_VortexTransform.name == "RedWarpZone")
        {
            // if red tank then good to go
            if (m_PlayerColour == Color.red)
            {
                m_isCorrectPortal = true;
                Debug.Log("Correct Portal");
            }
            // if green tank then wrong portal
            else if (m_PlayerColour == Color.green)
            {
                m_isCorrectPortal = false;
                Debug.Log("Wrong Portal");
            }
        }
        ///<summary>
        /// Check if Warp is called green warp zone then check which player has tried to enter
        /// </summary>
        else if (m_VortexTransform.name == "GreenWarpZone")
        {
            // if green tank then good to go
            if (m_PlayerColour == Color.green)
            {
                m_isCorrectPortal = true;
                Debug.Log("Correct Portal");
            }
            // if red tank then wrong portal
            else if (m_PlayerColour == Color.red)
            {
                m_isCorrectPortal = false;
                Debug.Log("Wrong Portal");
            }
        }
    }
}

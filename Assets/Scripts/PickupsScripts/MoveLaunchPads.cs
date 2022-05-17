using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveLaunchPads : MonoBehaviour
{
    private GameObject currentPad;

    private float m_MinMovement = 0.5f;

    private float m_MaxMovement = 4.5f;

    private float m_VelocityToMove = 2f;

    public GameObject[] allLaunchPads;

    private Transform thisPadsTransform;

    private Coroutine PadMovement;

    private Vector3 originalPadPosition;

    private Vector3 newPadPosition;

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        
    }


    private void OnDisable()
    {
        
    }

    public IEnumerator MovePads()
    {
        // currentPad = GetComponent<GameObject>();


        if (allLaunchPads == null)
        {
            allLaunchPads = GameObject.FindGameObjectsWithTag("LaunchPads");

            yield return null;
        }

        for (int i = 0; i < allLaunchPads.Length; i++)
        {
            thisPadsTransform = allLaunchPads[i].transform;

            currentPad = allLaunchPads[i];
            //  = currentPadToMoveNow;

            originalPadPosition = currentPad.transform.position;

            Vector3 randomMoveToLocation = new(Random.Range(m_MinMovement, m_MaxMovement), Random.Range(m_MinMovement, m_MaxMovement), 0);

            Rigidbody currentPadRigid = thisPadsTransform.GetComponent<Rigidbody>();

            currentPadRigid.isKinematic = false;

            currentPadRigid.MovePosition(thisPadsTransform.position + randomMoveToLocation);

            currentPadRigid.isKinematic = true;
            yield return 3;
            

            if (originalPadPosition != newPadPosition)
            {
                yield return 2;

                currentPadRigid.isKinematic = false;

                currentPadRigid.MovePosition(thisPadsTransform.position + originalPadPosition);

                currentPadRigid.isKinematic = true;

            }
        }



        yield return null;
    }
    public void MoveThePads()
    {
        StartCoroutine(MovePads());

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveLaunchPads : MonoBehaviour
{
    private GameObject currentPad;

    private float m_MinMovement = 0.5f;

    private float m_MaxMovement = 2.5f;

    // private float m_VelocityToMove = 2f;

    public GameObject[] allLaunchPads;

    private Transform thisPadsTransform;

    // private Coroutine PadMovement;

    private Vector3 originalPadPosition;

    private Vector3 newPadPosition;

    private void Start()
    {
        // StartCoroutine(MovePads());
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

        // check if all launch pads array is empty 
        if (allLaunchPads == null)
        {
            // add all the game objects with tag launch pads
            allLaunchPads = GameObject.FindGameObjectsWithTag("LaunchPads");
            Debug.Log("All LaunchPads added to array");
            yield return null;
        }
        else
        {
            yield return null;
        }

        for (int i = 0; i < allLaunchPads.Length; i++)
        {
            thisPadsTransform = allLaunchPads[i].transform;

            currentPad = allLaunchPads[i];
            //  = currentPadToMoveNow;

            originalPadPosition = currentPad.transform.position;
            float zeroOnYAxis = 0;

            Vector3 randomMovePositionIncrement = new(Random.Range(m_MinMovement, m_MaxMovement), Random.Range(m_MinMovement, m_MaxMovement), zeroOnYAxis);

            Rigidbody currentPadRigid = thisPadsTransform.GetComponent<Rigidbody>();

            currentPadRigid.isKinematic = false;

            Vector3 moveToPosition = originalPadPosition + randomMovePositionIncrement;

            currentPad.transform.position = Vector3.Lerp(originalPadPosition, moveToPosition, Time.deltaTime);
            //currentPadRigid.MovePosition(thisPadsTransform.position + randomMoveToLocation);

            currentPadRigid.isKinematic = true;

            // wait 3 seconds before moving again
            yield return 3;


            if (newPadPosition != originalPadPosition)
            {
                yield return 2;

                currentPadRigid.isKinematic = false;

                currentPad.transform.position = Vector3.Lerp(moveToPosition, originalPadPosition, Time.deltaTime);

                // currentPadRigid.MovePosition(thisPadsTransform.position + originalPadPosition);

                currentPadRigid.isKinematic = true;

            }
        }               

        yield return null;
    }
    public void MoveThePads()
    {
        Debug.Log("Check if the pads are moving");
        StartCoroutine(MovePads());
    }

    public void StopThePads()
    {
        StopCoroutine(MovePads());
    }
}

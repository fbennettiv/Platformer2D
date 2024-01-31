using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PitTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            GameObject trigger = GetNearestActiveCheckpoint();

            if (trigger != null)
            {
                collider.transform.position = trigger.transform.position; // Get the collider (player) position and set it to trigger position
            }
            else
            {
                Debug.LogError("No valid checkpoint was found!");
            }
        }
        else
        {
            Destroy(collider.gameObject);
        }
    }

    GameObject GetNearestActiveCheckpoint()
    {
        GameObject[] checkPoints = GameObject.FindGameObjectsWithTag("Checkpoint");

        GameObject nearestCheckPoint = null;

        float shortestDistance = Mathf.Infinity;

        foreach(GameObject checkPoint in checkPoints)
        {
            Vector3 checkPointPosition = checkPoint.transform.position;
            float distance = (checkPointPosition - transform.position).sqrMagnitude;

            CheckpointTrigger trigger = checkPoint.GetComponent<CheckpointTrigger>();

            if (distance < shortestDistance && trigger.isTriggered)
            {
                nearestCheckPoint = checkPoint;
                shortestDistance = distance;
            }
        }

        return nearestCheckPoint;
    }
}

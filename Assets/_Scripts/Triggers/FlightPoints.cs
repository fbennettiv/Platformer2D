using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using UnityEngine;

public class FlightPoints : MonoBehaviour
{
    public GameObject wayPointA;
    public GameObject wayPointB;

    public float speed = 1;
    public bool shouldChangeFacing = false;
    public bool isPlatform = false;

    private bool directionAB = false;

    void FixedUpdate()
    {
        if (transform.position == wayPointA.transform.position &&
            directionAB == false ||
            transform.position == wayPointB.transform.position &&
            directionAB == true) // transform.position is the fly's position (checking which way we are going, either to A to B or B to A)
        {
            directionAB = !directionAB;

            if (shouldChangeFacing)
            {
                gameObject.GetComponent<EnemyController>().Flip();
            }
        }

        if (directionAB)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                wayPointB.transform.position,
                speed * Time.fixedDeltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                wayPointA.transform.position,
                speed * Time.fixedDeltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (isPlatform && (collider.tag == "Player" || collider.tag == "Enemy"))
        {
            collider.gameObject.transform.parent = gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (isPlatform && (collider.tag == "Player" || collider.tag == "Enemy"))
        {
            collider.gameObject.transform.parent = null; // No longer anchored to the Platform
        }
    }
}

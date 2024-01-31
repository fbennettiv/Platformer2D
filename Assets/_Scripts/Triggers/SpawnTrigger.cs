using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    public GameObject[] gameObjects;

    public bool isTriggered = false;

    public bool isSpawned = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && !isTriggered)
        {
            isTriggered = true;

            foreach (GameObject gameObject in gameObjects) //Make sure you understand how it effects framerate
            {
                gameObject.SetActive(true);
            }
        }
    }
}

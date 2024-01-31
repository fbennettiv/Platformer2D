using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject poppedStatePrefab;
    public PlayerStats PlayerStats;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            DoorPop();
        }
    }

    public void DoorPop()
    {
        this.poppedStatePrefab.SetActive(true);
        this.gameObject.SetActive(false);
    }
}

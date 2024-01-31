using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class DiamondPickup : MonoBehaviour
{
    public int diamondNum = 1;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            PlayerStats stats =
                collider.gameObject.GetComponent<PlayerStats>();
            Destroy(gameObject);

            stats.CollectDiamonds(diamondNum);
        }
    }
}

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemSpawnPoint;
    public Object[] itemPrefabs;

    public int force;

    void Start()
    {
        SpawnItem();
    }

    void SpawnItem()
    {
        GameObject item = Object.Instantiate(
            itemPrefabs[Random.Range(0, itemPrefabs.Length)],
            itemSpawnPoint.transform.position,
            itemSpawnPoint.transform.rotation) as GameObject;

        item.GetComponent<Rigidbody2D>().
            AddForce(new Vector2(Random.Range(-120, 120), force));
    }
}

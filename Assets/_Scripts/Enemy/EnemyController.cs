using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [HideInInspector]
    public bool isFacingRight = false;

    public float maxSpeed = 1.5f;

    public void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 enemyScale = transform.localScale;
        enemyScale.x *= -1;
        transform.localScale = enemyScale;
    }
}

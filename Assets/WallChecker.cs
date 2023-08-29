using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallChecker : MonoBehaviour
{
    public bool canMove;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            canMove = false;
            EnemyMovement.Instance.canMove = canMove;
            Debug.Log("Wall for " + gameObject.name);
        }
        else
        {
            canMove = true;
            EnemyMovement.Instance.canMove = canMove;

        }
    }
}

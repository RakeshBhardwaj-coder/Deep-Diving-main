using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallChecking : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Prevent movement if player's collider is turned off
            if (!playerMovement.GetComponent<Collider2D>().enabled)
            {
                // Reverse the player's velocity to stay in place
                playerMovement.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
    }
}

using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    public Transform player;         // Assign the player's transform in the Inspector
    public float parallaxSpeed = 0.5f;
    public float stationaryAreaWidth = 5f;

    private Vector3 initialBackgroundPosition;

    private void Start()
    {
        initialBackgroundPosition = transform.position;
    }

    private void Update()
    {
        if (player != null)
        {
            float playerMovement = player.position.x;

            // Calculate the background's new position
            float backgroundX = initialBackgroundPosition.x + (playerMovement * parallaxSpeed);
            backgroundX = Mathf.Clamp(backgroundX, initialBackgroundPosition.x - stationaryAreaWidth, initialBackgroundPosition.x + stationaryAreaWidth);

            // Apply the new position to the background
            transform.position = new Vector3(backgroundX, transform.position.y, transform.position.z);
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
public class MovingImage : MonoBehaviour
{
    public float leftBoundary = -8.0f; // Set the starting left position
    public float rightBoundary = 8.0f; // Set the ending right position

    private Transform spriteTransform;
    private Vector3 startingPosition;
    private Vector3 targetPosition;
    private float currentSpeed;

    private void Start()
    {
        spriteTransform = transform;
        startingPosition = spriteTransform.position;
        targetPosition = new Vector3(rightBoundary, startingPosition.y, startingPosition.z);
        ResetSprite();
    }

    private void Update()
    {
        MoveSprite();
    }

    private void MoveSprite()
    {
        float step = currentSpeed * Time.deltaTime;
        spriteTransform.position = Vector3.MoveTowards(spriteTransform.position, targetPosition, step);

        // When the sprite reaches the right boundary, reset its position and speed
        if (spriteTransform.position.x >= rightBoundary)
        {
            ResetSprite();
        }
    }

    private void ResetSprite()
    {
        currentSpeed = Random.Range(1f, 2f); // Set a random speed range
        spriteTransform.position = startingPosition;
    }
}

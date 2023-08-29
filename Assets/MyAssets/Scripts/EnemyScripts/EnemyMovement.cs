using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform centerPoint; // Assign the center point in the Inspector
    public float movementRadius = 5f;
    public float moveSpeed = 2f;

    public bool canMove;
    private Vector2 initialPosition;
    //Singlton
    private static EnemyMovement _instance;

    public static EnemyMovement Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<EnemyMovement>();
            }

            return _instance;
        }
    }
    private void Start()
    {
        initialPosition = transform.position;
        canMove = true;
    }

    private void Update()
    {
        if (canMove)
        {
            EnemyMove();
        }
    }
   
    void EnemyMove()
    {

        // Calculate the target position within the movement area
        Vector2 targetPosition2D = initialPosition + Random.insideUnitCircle * movementRadius;

        // Calculate the movement direction
        Vector2 moveDirection = (targetPosition2D - (Vector2)transform.position).normalized;

        // Move the enemy
        transform.position += (Vector3)moveDirection * moveSpeed * Time.deltaTime;

        // Clamp the position within the movement area
        Vector2 clampedPosition = new Vector2(
            Mathf.Clamp(transform.position.x, initialPosition.x - movementRadius, initialPosition.x + movementRadius),
            Mathf.Clamp(transform.position.y, initialPosition.y - movementRadius, initialPosition.y + movementRadius)
        );

        transform.position = clampedPosition;
    }
}

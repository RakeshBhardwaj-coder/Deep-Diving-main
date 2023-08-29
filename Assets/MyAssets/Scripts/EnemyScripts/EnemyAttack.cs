using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 5f;
    public float attackCooldown = 2f;
    public float enemyAttackSpeed = 1f;

    private Transform player;
    private Vector3 originalPosition;
    private bool isReturning = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        originalPosition = transform.position;
    }

    private void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (isReturning)
            {
                // Return to original position
                Vector3 directionToOriginal = originalPosition - transform.position;
                transform.Translate(directionToOriginal.normalized * enemyAttackSpeed * Time.deltaTime);

                // Check if we've reached the original position
                if (Vector3.Distance(transform.position, originalPosition) < 0.1f)
                {
                    isReturning = false;
                }
            }
            else if (distanceToPlayer <= attackRange && GameManager.Instance.isAttack)
            {
                // Check for wall collisions before attacking
                RaycastHit hit;
                if (Physics.Raycast(transform.position, player.position - transform.position, out hit, attackRange))
                {
                    if (hit.collider.CompareTag("Wall"))
                    {
                        // Handle enemy behavior when colliding with a wall
                        isReturning = true;
                        return; // Don't proceed with attacking
                    }
                }

                Attack();
            }
            else if (!GameManager.Instance.isAttack && distanceToPlayer <= attackRange)
            {
                StartCoroutine(AttackCooldown());
            }
        }
    }

    // ... (rest of the code)

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        GameManager.Instance.isAttack = true;
    }


    private void Attack()
    {
        // Your attack logic here.
        Debug.Log("Attacking player!");
        // Calculate the direction from this object to the player.
        Vector3 directionToPlayer = player.position - transform.position;

        // Normalize the direction and move towards the player.
        transform.Translate(directionToPlayer.normalized * enemyAttackSpeed * Time.deltaTime);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

  

}


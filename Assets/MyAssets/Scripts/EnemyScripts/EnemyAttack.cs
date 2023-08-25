using UnityEngine;
using System.Collections;
public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 5f;
    public float attackCooldown = 2f;
    public float enemyAttackSpeed=1f;
    private Transform player;
    private bool canAttack = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (player != null)
        {

            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= attackRange && GameManager.Instance.isAttack)
            {
                Attack();

                /* StartCoroutine(AttackCooldown());*/
            }
            else if (!GameManager.Instance.isAttack && distanceToPlayer <= attackRange)
            {
                StartCoroutine(AttackCooldown());
            }
        }
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

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        GameManager.Instance.isAttack = true;
    }
}

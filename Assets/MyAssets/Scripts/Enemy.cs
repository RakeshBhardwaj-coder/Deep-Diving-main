using UnityEngine;

public class Enemy : MonoBehaviour
{
   

    public EnemyType enemyType;
    private EnemyDefination enemyDefination;

    private void Awake()
    {
        enemyDefination = new EnemyDefination(enemyType);
      
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // This code runs when the collider attached to this GameObject enters a trigger collider on another GameObject.

        // Check if the collision happened with a specific tag.
        if (otherCollider.CompareTag("Player"))
        {
            GameManager.Instance.ReduceHealth(enemyDefination.Power);
        }
    }
}

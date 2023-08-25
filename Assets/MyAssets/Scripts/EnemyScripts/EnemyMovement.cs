using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float moveRange = 10f;
    public float moveInterval = 3f;

    private NavMeshAgent navMeshAgent;
    private Vector3 randomPosition;
    private float timeSinceLastMove = 0f;

    private void Start()
    {
       
        navMeshAgent = GetComponent<NavMeshAgent>();

        //shouldn't rotate the objects in xy plane 
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        SetRandomDestination();
    }

    private void Update()
    {
        timeSinceLastMove += Time.deltaTime;

        if (timeSinceLastMove >= moveInterval)
        {
            SetRandomDestination();
        }
    }

    private void SetRandomDestination()
    {
        randomPosition = transform.position + Random.insideUnitSphere * moveRange;
        NavMeshHit navHit;

        if (NavMesh.SamplePosition(randomPosition, out navHit, moveRange, NavMesh.AllAreas))
        {
            navMeshAgent.SetDestination(navHit.position);
            timeSinceLastMove = 0f;
        }
    }
}

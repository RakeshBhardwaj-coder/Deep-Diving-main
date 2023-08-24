using UnityEngine;
using UnityEngine.AI;

public class MoveWithNavMesh : MonoBehaviour
{
    public Transform target; // The target position to move towards
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetDestination(target.position);
    }

    private void SetDestination(Vector3 destination)
    {
        if (navMeshAgent != null)
        {
            navMeshAgent.SetDestination(destination);
        }
    }
}

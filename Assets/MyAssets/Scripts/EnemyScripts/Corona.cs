using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corona : MonoBehaviour
{
    public Transform leftBoundary;
    public Transform rightBoundary;
    public float moveSpeed = 3f;

    private Transform target;

    private void Start()
    {
        target = rightBoundary;
    }

    private void Update()
    {
        MoveWithinRange();
    }

    private void MoveWithinRange()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        if (Vector3.Distance(transform.position, target.position) < 0.01f)
        {
            if (target == leftBoundary)
                target = rightBoundary;
            else
                target = leftBoundary;
        }
    }
}

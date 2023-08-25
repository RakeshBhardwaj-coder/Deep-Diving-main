using UnityEngine;

public class Gam : MonoBehaviour
{

    public GamType GamType;
    private GamDefination GamDefination;

    private void Awake()
    {
        GamDefination = new GamDefination(GamType);

    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // This code runs when the collider attached to this GameObject enters a trigger collider on another GameObject.

        // Check if the collision happened with a specific tag.
        if (otherCollider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}

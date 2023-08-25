using UnityEngine;

public class Treasure : MonoBehaviour
{

    public TreasureType treasureType;
    private TreasureDefination treasureDefination;

    private void Awake()
    {
        treasureDefination = new TreasureDefination(treasureType);

    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // This code runs when the collider attached to this GameObject enters a trigger collider on another GameObject.

        // Check if the collision happened with a specific tag.
        if (otherCollider.CompareTag("Player"))
        {
        }
    }
}

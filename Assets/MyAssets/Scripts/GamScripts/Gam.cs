using UnityEngine;

public class Gam : MonoBehaviour
{

    public int gamIndex;

    private void Awake()
    {

    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {

        // Check if the collision happened with a specific tag.
        if (otherCollider.CompareTag("Player"))
        {
            ScoreManager.Instance.UpdateScore(gamIndex);
            Destroy(gameObject);
        }
    }
}

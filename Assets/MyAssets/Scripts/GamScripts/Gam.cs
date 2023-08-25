using UnityEngine;

public class Gam : MonoBehaviour
{

    public int index;
    public int score;

    private void Awake()
    {

    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {

        // Check if the collision happened with a specific tag.
        if (otherCollider.CompareTag("Player"))
        {
            score++;
            ScoreManager.Instance.UpdateScore(index,score);
            Destroy(gameObject);
        }
    }
}

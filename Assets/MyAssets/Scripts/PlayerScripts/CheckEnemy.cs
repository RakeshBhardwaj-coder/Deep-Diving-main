using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemy : MonoBehaviour
{
    private Collider2D playerCollider;
    private bool canCollide = true;
    private SpriteRenderer playerSpriteRenderer;
    private bool isFlickering = false;

    private void Start()
    {
        playerCollider = GetComponent<Collider2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canCollide && collision.gameObject.CompareTag("Enemy"))
        {
            canCollide = false; // Disable collision temporarily
            playerCollider.enabled = false;

            // Call a method to re-enable the collider after a delay
            GameManager.Instance.ReduceHealth(1);
            isFlickering = true;
            StartCoroutine(FlickerRoutine(.5f));
            Invoke("EnableCollider", .3f);
        }
    }
    private void EnableCollider()
    {
        canCollide = true;
        playerCollider.enabled = true;
        PlayerAnimation.Instance.StopHurtAnimation();
    }
    private IEnumerator FlickerRoutine(float duration)
    {
        float flickerStartTime = Time.time;

        while (Time.time - flickerStartTime < duration)
        {
            playerSpriteRenderer.enabled = !playerSpriteRenderer.enabled;
            yield return new WaitForSeconds(0.1f); // Adjust the time interval for flickering
        }

        playerSpriteRenderer.enabled = true; // Ensure sprite is visible after flicker
        isFlickering = false; 
    }
}

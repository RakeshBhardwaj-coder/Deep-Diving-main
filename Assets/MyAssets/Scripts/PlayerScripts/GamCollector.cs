using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamCollector : MonoBehaviour
{
    Gam gam;
    public int golds;
    public int diamonds;
    public int rubys;

    public DestroyParticles destroyParticles;
    public ParticleSystem gamParticles;
    public Gradient[] gamColorParticles;
    int iColor;

    private void Awake()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        // Check if the collision happened with a specific tag.
        if (collision.gameObject.CompareTag("Gam"))
        {
            gam = collision.gameObject.GetComponent<Gam>();
            GamType gamType = gam.gamType;

            switch (gamType)
            {
                case GamType.Gold :
                    Gam.Instance.CollectedFirstCoin(); //tutorial will show at first time when player get the coins
                    golds++;
                    ScoreManager.Instance.UpdateScore(0, golds);
                    SoundManager.Instance.CoinAudioPlay(0);
                    iColor = 0;
                    break;
                case GamType.Diamond :
                    diamonds++;
                    ScoreManager.Instance.UpdateScore(1, diamonds);
                    SoundManager.Instance.CoinAudioPlay(1);
                    iColor = 1;
                    break;
                case GamType.Ruby :
                    rubys++;
                    ScoreManager.Instance.UpdateScore(2, rubys);
                    SoundManager.Instance.CoinAudioPlay(2);
                    iColor = 2;
                    break;
                case GamType.Heart :
                    Debug.Log("Hearted");
                    SoundManager.Instance.CoinAudioPlay(2);
                    HealthManager.Instance.IncreaseHealth();
                    iColor = 3;
                    break;
            }

           

        
            ParticleSystem instantiatedObject = Instantiate(gamParticles,new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f), Quaternion.identity);
            // Access the Particle System's ColorOverLifetime module directly.
            var colorOverLifetime = instantiatedObject.colorOverLifetime;
            // Set the color curve to the provided gradient.
            colorOverLifetime.color = gamColorParticles[iColor];
            instantiatedObject.Play();
            float particleSystemDuration = gamParticles.main.duration + gamParticles.main.startLifetime.constantMax;
            destroyParticles.DestoryTheParticles(instantiatedObject.gameObject, particleSystemDuration);
            Destroy(collision.gameObject);
        }
    }
}

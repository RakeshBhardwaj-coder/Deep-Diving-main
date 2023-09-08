using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamCollector : MonoBehaviour
{
    Gam gam;
    ParticleSystem gamParticles;
    public int golds;
    public int diamonds;
    public int rubys;

    private void Awake()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        // Check if the collision happened with a specific tag.
        if (collision.gameObject.CompareTag("Gam"))
        {
            gam = collision.gameObject.GetComponent<Gam>();
            gamParticles = Gam.Instance.gamParticles;
            GamType gamType = gam.gamType;

            switch (gamType)
            {
                case GamType.Gold :
                    Gam.Instance.CollectedFirstCoin(); //tutorial will show at first time when player get the coins

                    golds++;
                    ScoreManager.Instance.UpdateScore(0, golds);
                    SoundManager.Instance.CoinAudioPlay(0);
                    if (gamParticles != null)
                    {
                        // Instantiate the Particle System prefab.
                        ParticleSystem newParticleSystem = Instantiate(gamParticles, transform.position, Quaternion.identity);

                      
                        // Play the Particle System (if it's not set to Auto Play).
                        newParticleSystem.Play();
                        
                    }
                    break;
                case GamType.Diamond :
                    diamonds++;
                    ScoreManager.Instance.UpdateScore(1, diamonds);
                    SoundManager.Instance.CoinAudioPlay(1);
                    break;
                case GamType.Ruby :
                    rubys++;
                    ScoreManager.Instance.UpdateScore(2, rubys);
                    SoundManager.Instance.CoinAudioPlay(2);
                    break;
                case GamType.Heart :
                    Debug.Log("Hearted");
                    SoundManager.Instance.CoinAudioPlay(2);
                    HealthManager.Instance.IncreaseHealth();
                    break;
            }

          
           Destroy(collision.gameObject);
        }
    }
}

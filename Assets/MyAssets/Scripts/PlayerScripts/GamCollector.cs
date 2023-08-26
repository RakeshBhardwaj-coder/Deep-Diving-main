using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamCollector : MonoBehaviour
{
    Gam gam;
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
            GamType gamType = gam.gamType;

            switch (gamType)
            {
                case GamType.Gold :
                    Gam.Instance.CollectedFirstCoin(); //tutorial will show at first time when player get the coins
                    golds++;
                    ScoreManager.Instance.UpdateScore(0, golds);
                    SoundManager.Instance.CoinAudioPlay(0);
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
            }

            
            Destroy(collision.gameObject);
        }
    }
}

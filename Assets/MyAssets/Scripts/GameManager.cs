using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singlton
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }

    public int playerMaxHeart=4;
    public bool isAttack = true;


    public void GameOver()
    {
    }
    public void PauseGame()
    {
        Time.timeScale=0f;
    }
    public void ReduceHealth(int damage)
    {
        PlayerAnimation.Instance.HurtAnimation();
        HealthManager.Instance.ReduceHealth(damage);
        SoundManager.Instance.PlayHitttingAudio(); //sound
        isAttack = false;
       

    }

}

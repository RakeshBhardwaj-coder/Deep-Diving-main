using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigExplosionAnim : MonoBehaviour
{
  
    public void GameOverAnimEvent()
    {
        GameManager.Instance.GameOver();

    }
}

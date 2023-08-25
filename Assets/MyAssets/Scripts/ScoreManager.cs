using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    //Singlton
    private static ScoreManager _instance;

    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ScoreManager>();
            }

            return _instance;
        }
    }
    public Transform gamSpawningPosition;
    public TextMeshProUGUI[] gamText;
    
    void Start()
    {
        gamText[0].text = "0";
        gamText[1].text = "0";
        gamText[2].text = "0";
    }
    private void Update()
    {
      
    }

    public void UpdateScore(int position,int score)
    {
        gamText[position].text = score + "";

       
    }
}

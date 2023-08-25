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
    public TextMeshProUGUI[] gamTextGloble;
    public int goldScore = 0;
    public int localGoldScore = 0;
    public int diamondScore = 0;
    public int localDiamondScore = 0;
    public int rubyScore = 0;
    public int localRubyScore = 0;
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
        switch (position)
        {
            case 0:
                localGoldScore = score;
                break;
            case 1:
                localDiamondScore = score;
                break;
            case 2:
                localRubyScore= score;
                break;
        }
    }
    public void CollectBtn()
    {
        if (localGoldScore > 0)
        {
            goldScore = localGoldScore;
            gamTextGloble[0].text = goldScore+"";
            localGoldScore = 0;
        }
        if (localDiamondScore > 0)
        {
            diamondScore = localDiamondScore;
            gamTextGloble[1].text = diamondScore + "";
            localDiamondScore = 0;
        }
        if (localRubyScore > 0)
        {
            rubyScore = localRubyScore;
            gamTextGloble[2].text = rubyScore+ "";
            localRubyScore = 0;
        }

    }
}

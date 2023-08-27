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
    public bool isDiamondUI;
    public bool isGoldUI;
    public bool isRubyUI;

    public GameObject[] gamsCollections;

    Gam gam;
    void Start()
    {
        gamText[0].text = "0";
        gamText[1].text = "0";
        gamText[2].text = "0";
    }
    private void Update()
    {
        if (localGoldScore > 0)
        {
            PlayFakeGamAnimation(0, true);
        }
        else
        {
            PlayFakeGamAnimation(0, false);

        }
        if (localDiamondScore > 0)
        {
            PlayFakeGamAnimation(1, true);
        }
        else
        {
            PlayFakeGamAnimation(1, false);

        }
        if (localRubyScore > 0)
        {
            PlayFakeGamAnimation(2, true);
        }
        else
        {
            PlayFakeGamAnimation(2, false);

        }

    }

    public void UpdateScore(int position,int score)
    {
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
        if (localGoldScore == 0 && isGoldUI)
        {
            SoundManager.Instance.MenuSeleceSFX();

            TutorialManager.Instance.ShowTutorial("First Collect the gold then come here!!!",25);

        }
        else if (localGoldScore > 0 && isGoldUI)
        {
            goldScore = localGoldScore;
            gamTextGloble[0].text = goldScore+"";
            gamText[0].text = goldScore + "";
            localGoldScore = 0;
            SoundManager.Instance.CoinAudioPlay(3);
        }
        if (localDiamondScore == 0 && isDiamondUI)
        {
            SoundManager.Instance.MenuSeleceSFX();
            TutorialManager.Instance.ShowTutorial("First Collect the diamond then come here!!!",25);

        }
        else if (localDiamondScore > 0 && isDiamondUI)
        {
            diamondScore = localDiamondScore;
            gamTextGloble[1].text = diamondScore + "";
            gamText[1].text = diamondScore + "";
            localDiamondScore = 0;
            SoundManager.Instance.CoinAudioPlay(4);

        }
        if (localRubyScore == 0 && isRubyUI)
        {
            SoundManager.Instance.MenuSeleceSFX();
            TutorialManager.Instance.ShowTutorial("First Collect the ruby then come here!!!",25);
        }
        else if (localRubyScore > 0 && isRubyUI)
        {
            rubyScore = localRubyScore;
            gamTextGloble[2].text = rubyScore+ "";
            gamText[2].text = rubyScore + "";
            localRubyScore = 0;
            SoundManager.Instance.CoinAudioPlay(5);

        }

    }
    private void PlayFakeGamAnimation(int position,bool haveGams)
    {
        Animator animator;
        switch (position)
        {
            case 0:
                animator = gamsCollections[position].GetComponent<Animator>();
                animator.SetBool("isFakeGold", haveGams);
                break;
        }
       
    }

}

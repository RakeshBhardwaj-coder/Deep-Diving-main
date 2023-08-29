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
    int localGoldScore = 0;
    int localDiamondScore = 0;
    int localRubyScore = 0;
    public bool isDiamondUI;
    public bool isGoldUI;
    public bool isRubyUI;

    public int goldPref;
    public int diamondPref;
    public int rubyPref;
    
    public GameObject[] gamsCollections;

    Gam gam;
    void Start()
    {
        gamText[0].text = "0";
        gamText[1].text = "0";
        gamText[2].text = "0";

        PlayerPrefs.GetInt("GoldPref", 0); // 0 is the default value if "Score" is not found
        PlayerPrefs.GetInt("DiamondPref", 0); // 0 is the default value if "Score" is not found
        PlayerPrefs.GetInt("RubyPref", 0); // 0 is the default value if "Score" is not found
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

        goldPref = PlayerPrefs.GetInt("GoldPref", 0);
        diamondPref = PlayerPrefs.GetInt("DiamondPref", 0);
        rubyPref = PlayerPrefs.GetInt("RubyPref", 0);


        if (goldPref >= 60 && diamondPref >= 30 && rubyPref >= 20)
        {

            Debug.Log("Congratulations! You've won the game!");
            GameManager.Instance.isWinnedGame = true;
            GameManager.Instance.gameCanvas.SetActive(false);
            PlayerMovement.Instance.canMove = false;


        }
        else
        {

            Debug.Log("Keep playing to achieve victory!");
            GameManager.Instance.isWinnedGame = false;
            PlayerMovement.Instance.canMove = true;


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
            gamTextGloble[0].text = localGoldScore+"";
            gamText[0].text = localGoldScore + "";
            if (localGoldScore > PlayerPrefs.GetInt("GoldPref") )
            {
                PlayerPrefs.SetInt("GoldPref", localGoldScore);
                PlayerPrefs.Save(); // Save changes to disk (optional but can be useful)
            }
         
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
            gamTextGloble[1].text = localDiamondScore + "";
            gamText[1].text = localDiamondScore + "";
            if (localDiamondScore > PlayerPrefs.GetInt("DiamondPref"))
            {
                PlayerPrefs.SetInt("DiamondPref", localDiamondScore);
                PlayerPrefs.Save(); // Save changes to disk (optional but can be useful)
            }
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
            gamTextGloble[2].text = localRubyScore+ "";
            gamText[2].text = localRubyScore + "";
            if (localRubyScore > PlayerPrefs.GetInt("DiamondPref"))
            {
                PlayerPrefs.SetInt("RubyPref", localRubyScore);
                PlayerPrefs.Save(); // Save changes to disk (optional but can be useful)
            }
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
            case 1:
                animator = gamsCollections[position].GetComponent<Animator>();
                animator.SetBool("isFakeDiamond", haveGams);
                break;
            case 2:
                animator = gamsCollections[position].GetComponent<Animator>();
                animator.SetBool("isFakeRuby", haveGams);
                break;
        }
       
    }
    public void ResetScore()
    {
       
    }

}

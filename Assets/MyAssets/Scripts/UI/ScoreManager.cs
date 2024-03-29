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
    int localGoldScore;
    int localDiamondScore;
    int localRubyScore;
    public bool isDiamondUI;
    public bool isGoldUI;
    public bool isRubyUI;

    public int goldPref;
    public int diamondPref;
    public int rubyPref;


    private Transform player;

    public GameObject[] gamsCollections;

    Gam gam;
    void Start()
    {

        PlayerPrefs.GetInt("GoldPref", 0); // 0 is the default value if "Score" is not found
        PlayerPrefs.GetInt("DiamondPref", 0); // 0 is the default value if "Score" is not found
        PlayerPrefs.GetInt("RubyPref", 0); // 0 is the default value if "Score" is not found

      

        if (PlayerPrefs.HasKey("GoldPref2"))
        {
            gamText[0].text = ""+ PlayerPrefs.GetInt("GoldPref2");
            gamTextGloble[0].text = ""+ PlayerPrefs.GetInt("GoldPref2");

        }
        else
        {
            gamText[0].text = "0";

        }
        if (PlayerPrefs.HasKey("DiamondPref2"))
        {
            gamText[1].text = "" + PlayerPrefs.GetInt("DiamondPref2");
            gamTextGloble[1].text = "" + PlayerPrefs.GetInt("DiamondPref2");
        }
        else
        {
            gamText[1].text = "0";

        }
        if (PlayerPrefs.HasKey("RubyPref2"))
        {
            gamText[2].text = "" + PlayerPrefs.GetInt("RubyPref2");
            gamTextGloble[2].text = "" + PlayerPrefs.GetInt("RubyPref2");
        }
        else
        {
            gamText[2].text = "0";

        }

        if (PlayerPrefs.HasKey("LocalGolds"))
        {
            localGoldScore = SaveState.Instance.LoadLocalGold();
        }
        else
        {
            localGoldScore = 0;
        }
        if (PlayerPrefs.HasKey("LocalDiamonds"))
        {
            localDiamondScore = SaveState.Instance.LoadLocalDiamond();
        }
        else
        {
            localDiamondScore = 0;
        }
        if (PlayerPrefs.HasKey("LocalRubys"))
        {
            localRubyScore = SaveState.Instance.LoadLocalRuby();
        }
        else
        {
            localRubyScore = 0;
        }

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (PlayerPrefs.HasKey("LocalGolds") && localGoldScore>0)
        {
            localGoldScore = SaveState.Instance.LoadLocalGold();
            PlayFakeGamAnimation(0, true);

        }
        else
        {
            PlayFakeGamAnimation(0, false);

        }
        if (PlayerPrefs.HasKey("LocalDiamonds") && localDiamondScore>0)
        {
            localDiamondScore = SaveState.Instance.LoadLocalDiamond();
            PlayFakeGamAnimation(1, true);
        }
        else
        {
            PlayFakeGamAnimation(1, false);

        }
        if (PlayerPrefs.HasKey("LocalRuby") && localRubyScore>0)
        {
            localRubyScore = SaveState.Instance.LoadLocalRuby();
            PlayFakeGamAnimation(2, true);
        }
        else
        {
            PlayFakeGamAnimation(2, false);

        }

        goldPref = PlayerPrefs.GetInt("GoldPref2", 0);
        diamondPref = PlayerPrefs.GetInt("DiamondPref2", 0);
        rubyPref = PlayerPrefs.GetInt("RubyPref2", 0);


        if (goldPref >= 60 && diamondPref >= 30 && rubyPref >= 20)
        {

           /* Debug.Log("Congratulations! You've won the game!");*/
            GameManager.Instance.isWinnedGame = true;
            GameManager.Instance.gameCanvas.SetActive(false);

            if (player != null)
            {
                PlayerMovement.Instance.canMove = false;
            }

        }
        else
        {

           /* Debug.Log("Keep playing to achieve victory!");*/
            GameManager.Instance.isWinnedGame = false;
            if (player != null)
            {
                PlayerMovement.Instance.canMove = true;
            }

        }

    }

    public void UpdateScore(int position,int score)
    {
        switch (position)
        {
            case 0:
                localGoldScore = score;
                SaveState.Instance.SaveLocalGold(localGoldScore);
                break;
            case 1:
                localDiamondScore = score;
                SaveState.Instance.SaveLocalDiamond(localDiamondScore);
                break;
            case 2:
                localRubyScore= score;
                SaveState.Instance.SaveLocalRuby(localRubyScore);
                break;
        }
    }
    //world UI Collect button.
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
            if (localGoldScore > PlayerPrefs.GetInt("GoldPref2") )
            {
              /*  PlayerPrefs.SetInt("GoldPref", localGoldScore);*/
                PlayerPrefs.SetInt("GoldPref2", localGoldScore);
                PlayerPrefs.Save(); // Save changes to disk (optional but can be useful)
            }
         
            localGoldScore = 0;
            SaveState.Instance.SaveLocalGold(localGoldScore); //
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
            if (localDiamondScore > PlayerPrefs.GetInt("DiamondPref2"))
            {
                PlayerPrefs.SetInt("DiamondPref2", localDiamondScore);
                PlayerPrefs.Save(); // Save changes to disk (optional but can be useful)
            }
            localDiamondScore = 0;
            SaveState.Instance.SaveLocalDiamond(localDiamondScore); //
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
            if (localRubyScore > PlayerPrefs.GetInt("RubyPref2"))
            {
                PlayerPrefs.SetInt("RubyPref2", localRubyScore);
                PlayerPrefs.Save(); // Save changes to disk (optional but can be useful)
            }
            localRubyScore = 0;
            SaveState.Instance.SaveLocalRuby(localRubyScore); //
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
    
}

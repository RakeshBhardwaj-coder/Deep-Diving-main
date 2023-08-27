using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialManager : MonoBehaviour
{  //Singlton
    private static TutorialManager _instance;

    public static TutorialManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<TutorialManager>();
            }

            return _instance;
        }
    }
    public Text textTutorial;
    public Animator animator;
    string isTutorialShow = "IsTutorialShow";
    bool canTutorialShow = false;

    private bool hasFirstMove = false;

    private void Start()
    {

        /* hasFirstMove = PlayerPrefs.GetInt("HasFirstMove", 0) == 1;*/

        // Check if the player has seen the tutorial before

    }
    void Update()
    {
       
    }

    public void CloseTutorial()
    {
        // Called when the player closes the tutorial
     /*   tutorialCanavs.SetActive(false);*/
        animator.SetBool(isTutorialShow, false);
    }

    public void FirstMove()
    {

        if (!hasFirstMove)
        {
            hasFirstMove = true;
            ShowTutorial("Move - WASD/Arrow keys,\n\nDiving - Shift + WASD / Arrow kesy", 25);
           /* // Save the status of first coin collection
            PlayerPrefs.SetInt("HasCollectedFirstCoin", 1);*/
/*
            PlayerPrefs.Save();*/

        }
    }
    public void ShowTutorial(string text,int fontSize)
    {
        canTutorialShow = true;
        animator.SetBool(isTutorialShow, canTutorialShow);
        SoundManager.Instance.MessageSFX();
        textTutorial.text = text;
        textTutorial.fontSize = fontSize;

    }
}

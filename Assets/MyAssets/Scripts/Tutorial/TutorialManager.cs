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
    private void Start()
    {
        PlayerPrefs.SetInt("FirstGold", 0);
        animator.SetBool(isTutorialShow, true);

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

    public void ShowTutorial(string text,int fontSize)
    {
        canTutorialShow = true;
        animator.SetBool(isTutorialShow, canTutorialShow);
        textTutorial.text = text;
        textTutorial.fontSize = fontSize;

    }
}

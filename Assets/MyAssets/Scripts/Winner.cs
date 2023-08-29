using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winner : MonoBehaviour
{
    //Singlton
    private static Winner _instance;

    public static Winner Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Winner>();
            }

            return _instance;
        }
    }
    public bool winner;
    public GameObject winnerCanvas;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        winnerCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      
            GameWinner();
        
    }
    public void GameWinner()
    {
        if (GameManager.Instance.isWinnedGame)
        {
            winnerCanvas.SetActive(true);

        }
        else
        {
            winnerCanvas.SetActive(false);

        }
    }

    public void WinnerText()
    {
        animator.SetBool("isWinnerText", true);
    }
    public void WinTextOcsilate()
    {
        animator.SetBool("isOcsilate", true);

    }

}

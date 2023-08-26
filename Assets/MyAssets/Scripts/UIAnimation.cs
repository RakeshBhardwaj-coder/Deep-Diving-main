using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    public Animator animator;
    Gam gam;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        { 
        
            gam = gameObject.GetComponent<Gam>();
            GamType gamType = gam.gamType;
            switch (gamType)
            {
                case GamType.Gold:
                ScoreManager.Instance.isGoldUI = true;
                    break;
                case GamType.Diamond:
                    ScoreManager.Instance.isDiamondUI = true;
                    break;
                case GamType.Ruby:
                ScoreManager.Instance.isRubyUI = true;
                    break;
            }
            animator.SetBool("isTriggerd", true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gam = gameObject.GetComponent<Gam>();
            GamType gamType = gam.gamType;
            switch (gamType)
            {
                case GamType.Gold:
                    ScoreManager.Instance.isGoldUI = false;
                    break;
                case GamType.Diamond:
                    ScoreManager.Instance.isDiamondUI = false;
                    break;
                case GamType.Ruby:
                    ScoreManager.Instance.isRubyUI = false;
                    break;
            }
            animator.SetBool("isTriggerd", false);
        }
    }
}




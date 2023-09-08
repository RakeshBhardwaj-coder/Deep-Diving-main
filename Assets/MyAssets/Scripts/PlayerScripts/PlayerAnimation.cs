using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //Singlton
    private static PlayerAnimation _instance;

    public static PlayerAnimation Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<PlayerAnimation>();
            }

            return _instance;
        }
    }

    string IDEAL = "IsIdeal";
    string SWIMMING = "IsSwimming";
    string DIVING = "IsDiving";
    string RUSH = "IsRush";
    string HURT = "IsHurted";

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

   
    public void IdealAnimation()
    {
        animator.SetBool(DIVING, false);
        animator.SetBool(SWIMMING, false);
    }
    public void DivingAnimation(bool isDiving)
    {
        animator.SetBool(DIVING, isDiving);
    }
    public void RushAnimation(bool isRushing)
    {
        animator.SetBool(RUSH, isRushing);
    }
    public void SwimmingAnimation()
    {
        animator.SetBool(SWIMMING, true);

    }
    public void HurtAnimation()
    {
        animator.SetBool(HURT, true);
        
    }
    public void StopHurtAnimation()
    {
        animator.SetBool(HURT, false);

    }
}

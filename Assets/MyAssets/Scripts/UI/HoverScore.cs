using UnityEngine;
using UnityEngine.EventSystems;

public class HoverScore : MonoBehaviour
{
    public Animator animator;
    public string AnimName;

    private void OnMouseEnter()
    {
        animator.SetBool(AnimName, true);
    }

    private void OnMouseExit()
    {
        animator.SetBool(AnimName, false);
    }
}

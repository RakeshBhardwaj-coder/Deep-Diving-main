using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerAnimation : MonoBehaviour
{
    public void WinnerTextShow()
    {
        Winner.Instance.WinnerText();
    }
    public void WinTextOcsilateShow()
    {
        Winner.Instance.WinTextOcsilate();

    }
}

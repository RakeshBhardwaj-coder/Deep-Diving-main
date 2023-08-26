using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseTime : MonoBehaviour
{
    public void TimePause()
    {
        Time.timeScale = 0f; // same button for pause and unPause

    }
}

using UnityEngine;

// using in the pause canvas animation 
public class PauseTime : MonoBehaviour
{
    public void TimePause()
    {
        Time.timeScale = 0f; // same button for pause and unPause

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class WinningSound : MonoBehaviour
{
    
    public AudioSource winAudio;
    public AudioSource bgAudio;

    public void PlayWinAudio()
    {
        winAudio.Play();
        bgAudio.Stop();
    }
}

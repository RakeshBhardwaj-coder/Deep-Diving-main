using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SoundManager : MonoBehaviour
{
    public AudioClip explosionSFX;
    public AudioClip[] hittingSFX;
    public AudioClip[] coinSFX;
    private AudioSource audioSource;
    public AudioClip damage;
    public AudioClip message;
    public AudioClip winning;
    public AudioClip[] buttonClicked;
    //Singlton
    private static SoundManager _instance;

    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<SoundManager>();
            }

            return _instance;
        }
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayExplosionAudio()
    {
        audioSource.PlayOneShot(explosionSFX);
    }
    public void PlayHitttingAudio()
    {
        audioSource.PlayOneShot(hittingSFX[Random.Range(0,hittingSFX.Length)]);
    }
    public void CoinAudioPlay(int index)
    {
        audioSource.PlayOneShot(coinSFX[index]);
    }
    public void MenuSeleceSFX()
    {
        audioSource.PlayOneShot(buttonClicked[0]);
    }
    public void MessageSFX()
    {
        audioSource.PlayOneShot(message);
    }
    public void ButtonClickedSFX()
    {
        audioSource.PlayOneShot(buttonClicked[1]);
    }
    public void WinnerSFX()
    {
        audioSource.PlayOneShot(winning);
    }
  
}

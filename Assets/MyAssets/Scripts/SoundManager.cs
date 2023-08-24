using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SoundManager : MonoBehaviour
{
    public AudioClip explosionSFX;
    public AudioClip[] hittingSFX;
    private AudioSource audioSource;
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
    }public void PlayHitttingAudio()
    {
        audioSource.PlayOneShot(hittingSFX[Random.Range(0,hittingSFX.Length)]);
    }
}

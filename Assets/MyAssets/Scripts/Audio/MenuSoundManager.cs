using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MenuSoundManager : MonoBehaviour
{
    public AudioClip menuSelectSFX;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void MenuSelect()
    {
        audioSource.PlayOneShot(menuSelectSFX);
    }
}

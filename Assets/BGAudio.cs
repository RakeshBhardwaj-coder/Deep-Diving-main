using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGAudio : MonoBehaviour
{
    public AudioSource bgAudio;

    private void Start()
    {
        bgAudio.Play();
    }
}

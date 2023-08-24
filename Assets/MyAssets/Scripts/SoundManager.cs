using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SoundManager : MonoBehaviour
{
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
}

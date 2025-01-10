using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{

      //Singlton
    private static Checkpoints _instance;

    public static Checkpoints Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Checkpoints>();
            }

            return _instance;
        }
    }
     
     public static Vector2 lastCheckpointPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
           // playerRespawnPoint = transform ;
           lastCheckpointPosition = transform.position;
            Debug.Log("checkpoint");
            PlayerPrefs.SetFloat("CheckpointX", lastCheckpointPosition.x);
            PlayerPrefs.SetFloat("CheckpointY", lastCheckpointPosition.y);
            
        }
    }
}

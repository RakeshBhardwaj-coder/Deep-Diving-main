using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    //Singlton
    private static ScoreManager _instance;

    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ScoreManager>();
            }

            return _instance;
        }
    }
    public GameObject gamPrefab;
    public Transform scoreSpawnPoint;
    TMP_Text gamScore;
    private int score = 0;
    void Start()
    {
        CreateGamUI();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IncreaseScore();
        }
    }

    private void IncreaseScore()
    {
        score++;
        UpdateScore();
    }

    private void CreateGamUI()
    {
        // Instantiate the score UI prefab at the spawn point
        GameObject gamUI = Instantiate(gamPrefab, scoreSpawnPoint);
        // Get the Image and Text components from the UI prefab
        Image gamImage = gamUI.GetComponentInChildren<Image>();
        gamScore = gamUI.GetComponentInChildren<TMP_Text>();
     /*   gamUI.transform.localPosition = Vector3.right  * gamImage.rectTransform.sizeDelta.x;*/



        // Set the score text
        gamScore.text = score.ToString();

        // Optionally, you can update other UI elements here (e.g., animations, sounds)
    }
    void UpdateScore()
    {
        gamScore.text = score.ToString();

    }
}

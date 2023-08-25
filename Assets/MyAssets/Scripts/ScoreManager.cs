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
    public GameObject[] gamPrefab;
    public Transform gamSpawningPosition;
   
    public Sprite[] gamSprite;
    private int[] gamScore;
    private int rubyGam = 0;
    private int diamondGam = 0;
    void Start()
    {
        gamScore = new int []{ 0, 0, 0 };
        InitializeGams();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
        }
    }


    private void InitializeGams()
    {
        for (int i = 0; i < gamSprite.Length; i++)
        {
            GameObject gamUI = Instantiate(gamPrefab[i], gamSpawningPosition);
            Image gamImage = gamUI.GetComponent<Image>();
            TMP_Text gamScoreTxt = gamUI.GetComponent<TMP_Text>();
            // Find the child TMP Text component by name
            TextMeshProUGUI childTMPText = gamUI.transform.Find("gamText").GetComponent<TextMeshProUGUI>();

            if (childTMPText != null)
            {
                childTMPText.text = gamScore[i]+"";
            }
            else
            {
                Debug.LogWarning("Error in ScoreManager GamText");
            }
          
            gamUI.transform.localPosition = Vector3.right  * gamImage.rectTransform.sizeDelta.x * i/1.2f;
        }
    }
    public void UpdateScore(int position)
    {
        gamScore[position]++;
        string arrayValues = string.Join(", ", gamScore);
        Debug.Log("Array values: " + arrayValues);
    }
}

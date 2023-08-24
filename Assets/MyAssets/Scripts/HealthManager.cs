using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    //Singlton
    private static HealthManager _instance;

    public static HealthManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<HealthManager>();
            }

            return _instance;
        }
    }
    public GameObject heartPrefab;
    public Transform heartsContainer;
    public Sprite emptyHeartSprite;
    public Sprite filledHeartSprite;

    public int currentHearts;
    private int maxHearts;

    private void Start()
    {
        maxHearts = GameManager.Instance.playerMaxHeart;
        currentHearts = maxHearts;
        InitializeHearts();
    }

    void Update()
    {
      
        if (currentHearts == 0)
        {
            GameManager.Instance.GameOver();
           /* vFXManager.SpawnVFX();*/

        }

    }
    private void InitializeHearts()
    {
        for (int i = 0; i < maxHearts; i++)
        {
           /* Image heart = Instantiate(heartPrefab, heartsContainer);
            heart.sprite = filledHeartSprite;*/

            GameObject heart = Instantiate(heartPrefab, heartsContainer);
            Image heartImage = heart.GetComponent<Image>();
            heartImage.sprite = filledHeartSprite;
            heart.transform.localPosition = Vector3.right * i * (heartImage.rectTransform.sizeDelta.x + 10f);
        }
    }


    public void ReduceHealth(int damage)
    {
        if (currentHearts > 0)
        {
           
                currentHearts--;
                heartsContainer.GetChild(currentHearts).GetComponent<Image>().sprite = emptyHeartSprite;
           
          
        }
    }

    public void IncreaseHealth()
    {
        if (currentHearts < maxHearts)
        {
            heartsContainer.GetChild(currentHearts).GetComponent<Image>().sprite = filledHeartSprite;
            currentHearts++;
        }
    }
}

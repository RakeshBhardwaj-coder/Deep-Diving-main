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
   
    public Sprite emptyHeartSprite;
    public Sprite filledHeartSprite;

    public Image[] heartImages; // Array to hold the heart images


    public int currentHearts;
    private int maxHearts;

   
    private void Start()
    {
        maxHearts = GameManager.Instance.playerMaxHeart;
        if (PlayerPrefs.HasKey("PlayerHeart"))
        {
            currentHearts = SaveState.Instance.LoadHearts();

        }
        else
        {
            currentHearts = maxHearts;
        }
        UpdateUI();
        

    }

 // new method
    private void UpdateUI()
    {
        // Loop through the heart images and update their sprites to represent current health
        for (int i = 0; i < maxHearts; i++)
        {
            if (i < currentHearts)
            {
                // Heart is full
                heartImages[i].sprite = filledHeartSprite;
            }
            else
            {
                // Heart is empty
                heartImages[i].sprite = emptyHeartSprite;
            }
        }
    }
    //old method
  /*  private void InitializeHearts()
    {
        for (int i = 0; i < maxHearts; i++)
        {
           *//* Image heart = Instantiate(heartPrefab, heartsContainer);
            heart.sprite = filledHeartSprite;*//*

            GameObject heart = Instantiate(heartPrefab, heartsContainer);
            Image heartImage = heart.GetComponent<Image>();
            heartImage.sprite = filledHeartSprite;
            heart.transform.localPosition = Vector3.right * i * (heartImage.rectTransform.sizeDelta.x + 10f);
        }
    }*/


    public void ReduceHealth(int damage)
    {
        if (currentHearts > 0)
        {

            currentHearts--;
            UpdateUI();
            SaveState.Instance.SaveHearts(currentHearts);
           
          
        }
    }

    public void IncreaseHealth()
    {
        if (currentHearts < maxHearts)
        {
            currentHearts++;
            UpdateUI();
            SaveState.Instance.SaveHearts(currentHearts);

        }
    }
}

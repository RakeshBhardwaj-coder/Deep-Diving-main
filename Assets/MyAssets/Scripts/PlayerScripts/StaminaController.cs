using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StaminaController : MonoBehaviour
{
    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaRegenRate = 5f; // Rate at which stamina regenerates per second.
    public float staminaDepletionAmount = 10f; // Amount of stamina to deplete when the button is clicked.
    public Image staminaBar;

    private bool isWait = false;
    void Start()
    {
        currentStamina = maxStamina;
    }

    void Update()
    {
          
        // Update the UI to reflect the current stamina.
        UpdateStaminaBar();

        if (GameManager.Instance.isBoosted && !isWait)
        {
            DepleteStamina();
        }
      else
        {
            RegenerateStamina();
        }
        

    }

    //if button is released then regenerate stamina
    void RegenerateStamina()
    {
        if (currentStamina < maxStamina)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
        }
    }
   
    //if button is clicked then Deplete stamina
    void DepleteStamina()
    {
        if (currentStamina > 0.1f)
        {
            currentStamina -= staminaDepletionAmount * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0f, currentStamina);
        }
        if (currentStamina < 0.1f)
        {
            isWait = true;
        }
       
     
    }

    void UpdateStaminaBar()
    {
        float fillAmount = currentStamina / maxStamina;
        staminaBar.fillAmount = fillAmount;
    }

  
}

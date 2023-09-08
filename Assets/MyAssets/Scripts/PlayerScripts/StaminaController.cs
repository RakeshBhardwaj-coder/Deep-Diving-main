using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StaminaController : MonoBehaviour
{
    public float maxStamina = 100f;
    public float currentStamina;
    public float waitForStamina;
    public float staminaRegenRate = 5f; // Rate at which stamina regenerates per second.
    public float staminaDepletionAmount = 10f; // Amount of stamina to deplete when the button is clicked.
    public Image staminaBar;

    public Image staminaBtn;


    private bool isWait = false;
    void Start()
    {
        currentStamina = maxStamina;
    }

    void Update()
    {
          
        // Update the UI to reflect the current stamina.
        UpdateStaminaBar();

        if (GameManager.Instance.isBoosted)
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
        if (currentStamina < maxStamina && !isWait)
        {
           Color currentColor = staminaBtn.color;
           currentColor.a = 124f;
           staminaBtn.color = currentColor;
            
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
        else if( currentStamina < .1f)
        {
            isWait = true;
            
            StartCoroutine(WaitForStamina());

        }
        if (isWait)
        {
            GameManager.Instance.isBoosted = false;
            Color currentColor = staminaBtn.color;
            currentColor.a = 0f;
            staminaBtn.color = currentColor;
        }
       


    }

    void UpdateStaminaBar()
    {
        float fillAmount = currentStamina / maxStamina;
        staminaBar.fillAmount = fillAmount;
    }
    IEnumerator WaitForStamina()
    {
   
        yield return new WaitForSeconds(waitForStamina); // wait for stamina gain when stamin is zero
        isWait = false;
    }

  
}

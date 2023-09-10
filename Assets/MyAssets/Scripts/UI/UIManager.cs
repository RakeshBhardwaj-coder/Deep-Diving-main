using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class UIManager : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider loadingSlider;
    public GameObject loadingPanel;
    public AudioClip buttonClicked;
    public AudioSource audioSource;

    private void Start()
    {
        // Initialize volume slider
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.8f);
    }

    public void PlayButtonClicked()
    {
        // Show loading panel
        loadingPanel.SetActive(true);

        StartCoroutine(LoadGameScene());
        DeleteKeys();
    }

    public void DeleteKeys()
    {
        // Check if collected coin data exists and delete it resets the SaveState
        if (PlayerPrefs.HasKey("CollectedCoins"))
        {
            PlayerPrefs.DeleteKey("CollectedCoins");
        }
        if (PlayerPrefs.HasKey("PlayerX"))
        {
            PlayerPrefs.DeleteKey("PlayerX");
        }
        if (PlayerPrefs.HasKey("PlayerY"))
        {
            PlayerPrefs.DeleteKey("PlayerY");
        }
        if (PlayerPrefs.HasKey("PlayerHeart"))
        {
            PlayerPrefs.DeleteKey("PlayerHeart");
        }
        if (PlayerPrefs.HasKey("LocalGolds"))
        {
            PlayerPrefs.DeleteKey("LocalGolds");
        }
        if (PlayerPrefs.HasKey("LocalDiamonds"))
        {
            PlayerPrefs.DeleteKey("LocalDiamonds");
        }
        if (PlayerPrefs.HasKey("LocalRubys"))
        {
            PlayerPrefs.DeleteKey("LocalRubys");
        }

        if (PlayerPrefs.HasKey("GoldPref2"))
        {
            PlayerPrefs.DeleteKey("GoldPref2");
        }
        if (PlayerPrefs.HasKey("DiamondPref2"))
        {
            PlayerPrefs.DeleteKey("DiamondPref2");
        }
        if (PlayerPrefs.HasKey("RubyPref2"))
        {
            PlayerPrefs.DeleteKey("RubyPref2");
        }


    }

    public void ResumeSaveGame()
    {

        // Show loading panel
        loadingPanel.SetActive(true);

        StartCoroutine(LoadGameScene());

    }
    private IEnumerator LoadGameScene()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Game");

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f); // Limit to 0-1 range
            loadingSlider.value = progress;
            yield return null; // Wait for the next frame
        }
    }
    void Update()
    {
        VolumeSliderChanged();
    }
    public void OptionsButtonClicked()
    {
        // Handle options menu UI or settings
        // You can enable/disable UI elements or open a settings panel
    }

    public void VolumeSliderChanged()
    {
        // Adjust the audio volume based on the slider value
        float volume = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volume);
        AudioListener.volume = volume;
    }

    public void ExitButtonClicked()
    {
        // Quit the application
        Application.Quit();
    }
    public void ResetTheGame()
    {
        PlayerPrefs.SetInt("GoldPref2", 0); // 0 is the default value if "Score" is not found
        PlayerPrefs.SetInt("DiamondPref2", 0); // 0 is the default value if "Score" is not found
        PlayerPrefs.SetInt("RubyPref2", 0); // 0 is the default value if "Score" is not found

        if (PlayerPrefs.HasKey("HasCollectedFirstCoin"))
        {
            PlayerPrefs.SetInt("HasCollectedFirstCoin", 0);
        }   
        if (PlayerPrefs.HasKey("HasFirstMove"))
        {
            PlayerPrefs.SetInt("HasFirstMove", 0);
        }
        PlayerPrefs.Save();

        DeleteKeys();
    }
        public void ClickSound()
    {
        audioSource.PlayOneShot(buttonClicked);
    }
}

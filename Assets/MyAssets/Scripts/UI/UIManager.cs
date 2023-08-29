using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class UIManager : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider loadingSlider;
    public GameObject loadingPanel;
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
        PlayerPrefs.SetInt("GoldPref", 0); // 0 is the default value if "Score" is not found
        PlayerPrefs.SetInt("DiamondPref", 0); // 0 is the default value if "Score" is not found
        PlayerPrefs.SetInt("RubyPref", 0); // 0 is the default value if "Score" is not found
        PlayerPrefs.Save();
    }
}

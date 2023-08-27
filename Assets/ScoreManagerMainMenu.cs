using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerMainMenu : MonoBehaviour
{

    public Text[] highScoreTexts; // Array of UI Text elements to display high scores

    private int[] highScores = new int[3]; // Array to store high scores

    private void Start()
    {
        LoadHighScores();
        UpdateHighScoreTexts();
    }

    private void LoadHighScores()
    {
        for (int i = 0; i < highScores.Length; i++)
        {
            highScores[i] = PlayerPrefs.GetInt("HighScore" + i, 0);
        }
    }

    private void UpdateHighScoreTexts()
    {
        for (int i = 0; i < highScoreTexts.Length; i++)
        {
            highScoreTexts[i].text = "High Score " + i + ": " + highScores[i];
        }
    }

    public void UpdateHighScore(int score)
    {
        // Check if the new score is higher than any of the existing high scores
        for (int i = 0; i < highScores.Length; i++)
        {
            if (score > highScores[i])
            {
                // Move other scores down the list
                for (int j = highScores.Length - 1; j > i; j--)
                {
                    highScores[j] = highScores[j - 1];
                }
                highScores[i] = score;
                SaveHighScores();
                UpdateHighScoreTexts();
                break;
            }
        }
    }

    private void SaveHighScores()
    {
        for (int i = 0; i < highScores.Length; i++)
        {
            PlayerPrefs.SetInt("HighScore" + i, highScores[i]);
        }
    }

    public void ResetHighScores()
    {
        for (int i = 0; i < highScores.Length; i++)
        {
            highScores[i] = 0;
            PlayerPrefs.SetInt("HighScore" + i, 0);
        }
        UpdateHighScoreTexts();
    }
}

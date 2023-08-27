
using TMPro;
using UnityEngine;
public class ScoreManagerMainMenu : MonoBehaviour
{


    private int[] highScores = new int[3]; // Array to store high scores
    public TextMeshProUGUI[] gamText;
    private void Start()
    {
    }
    void Update()
    {
        if (PlayerPrefs.HasKey("GoldPref"))
        {
            gamText[0].text = PlayerPrefs.GetInt("GoldPref") + "";
        }
        if (PlayerPrefs.HasKey("DiamondPref"))
        {
            gamText[1].text = PlayerPrefs.GetInt("DiamondPref") + "";
        }
        if (PlayerPrefs.HasKey("RubyPref"))
        {
            gamText[2].text = PlayerPrefs.GetInt("RubyPref") + "";
        }

    }

}

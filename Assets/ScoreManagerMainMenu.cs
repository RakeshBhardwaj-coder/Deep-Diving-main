
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
        if (PlayerPrefs.HasKey("GoldPref2"))
        {
            gamText[0].text = PlayerPrefs.GetInt("GoldPref2") + "";
        }
        if (PlayerPrefs.HasKey("DiamondPref2"))
        {
            gamText[1].text = PlayerPrefs.GetInt("DiamondPref2") + "";
        }
        if (PlayerPrefs.HasKey("RubyPref2"))
        {
            gamText[2].text = PlayerPrefs.GetInt("RubyPref2") + "";
        }

    }

}

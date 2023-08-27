using UnityEngine;
public enum GamType
{
    Gold,
    Diamond,
    Ruby,
    Heart
}

public class Gam : MonoBehaviour
{
    //Singlton
    private static Gam _instance;

    public static Gam Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Gam>();
            }

            return _instance;
        }
    }
    public GamType Type { get; private set; }

    public Gam(GamType gamType)
    {
        Type = gamType;
    }

    public GamType gamType;
    private Gam gam;
    private bool hasCollectedFirstCoin = false;

    private void Start()
    {
        gam = new Gam(gamType);

        // Load the saved status of first coin collection
        hasCollectedFirstCoin = PlayerPrefs.GetInt("HasCollectedFirstCoin", 0) == 1;

        // Show message if the player hasn't collected the first coin yet
        if (!hasCollectedFirstCoin)
        {
        }
       
    }
    public void CollectedFirstCoin()
    {

        if (!hasCollectedFirstCoin)
        {
            hasCollectedFirstCoin = true;
            TutorialManager.Instance.ShowTutorial("Go to gold \"Collection-Boat\" and save the Gold", 25);
            // Save the status of first coin collection
            PlayerPrefs.SetInt("HasCollectedFirstCoin", 1);

            PlayerPrefs.Save();

        }
    }
}

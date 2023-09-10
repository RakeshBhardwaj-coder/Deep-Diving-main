using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveState : MonoBehaviour
{
    //Singlton
    private static SaveState _instance;

    public static SaveState Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<SaveState>();
            }

            return _instance;
        }
    }

    public bool check;

    public List<GameObject> allCoins = new List<GameObject>();
    private HashSet<GameObject> collectedCoins = new HashSet<GameObject>();
    public GameObject player;

    public Vector2 playerInitialPosition;

    void Start()
    {
        playerInitialPosition = new Vector2(-5.22f, -.63f);
        player.transform.position = playerInitialPosition;
        LoadGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (check)
        {
            check = false;
            SceneManager.LoadScene("Game");
        }
      
        SavePlayerPosition(player.transform.position);



    }
    void LoadGame()
    {
        LoadPlayerPosition();
        LoadCollectedCoins();
        LoadHearts();
        

    }
    // Add a coin to the list when it's collected
    public void CollectCoin(GameObject coin)
    {
        if (allCoins.Contains(coin) && !collectedCoins.Contains(coin))
        {
            collectedCoins.Add(coin);
            coin.SetActive(false); // Hide the collected coin
            SaveCollectedCoins();
        }
    }

    public int LoadHearts()
    {
        int savedHearts = PlayerPrefs.GetInt("PlayerHeart");
        return savedHearts;
    }
    public void SaveHearts(int heart)
    {
        PlayerPrefs.SetInt("PlayerHeart", heart);
        PlayerPrefs.Save();
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
    }

    
    public void SaveLocalGold(int score)
    {
        PlayerPrefs.SetInt("LocalGolds", score);
        PlayerPrefs.Save();
    }
    public void SaveLocalDiamond(int score)
    {
        PlayerPrefs.SetInt("LocalDiamonds", score);
        PlayerPrefs.Save();
    }
    public void SaveLocalRuby(int score)
    {
        PlayerPrefs.SetInt("LocalRubys", score);
        PlayerPrefs.Save();
    }
    public int LoadLocalGold()
    {
        int value = PlayerPrefs.GetInt("LocalGolds");
        return value;
    }

    public int LoadLocalDiamond()
    {
        int value = PlayerPrefs.GetInt("LocalDiamonds");
        return value;
    }
   
    public int LoadLocalRuby()
    {
        int value = PlayerPrefs.GetInt("LocalRubys");
        return value;
    }
   
    public void SaveCollectedCoins()
      {
          // Convert the HashSet to a List for serialization
          List<string> collectedCoinNames = new List<string>();

          foreach (GameObject collectedCoin in collectedCoins)
          {
              collectedCoinNames.Add(collectedCoin.name);
          }

          // Serialize and save the list of collected coin names
          string collectedCoinData = string.Join(",", collectedCoinNames.ToArray());
          PlayerPrefs.SetString("CollectedCoins", collectedCoinData);
          PlayerPrefs.Save();
          Debug.Log("data saved");

    }

    public void LoadCollectedCoins()
      {
          if (PlayerPrefs.HasKey("CollectedCoins"))
          {
              string collectedCoinData = PlayerPrefs.GetString("CollectedCoins", "");
              List<string> collectedCoinNames = new List<string>(collectedCoinData.Split(','));

              collectedCoins.Clear();

              foreach (string coinName in collectedCoinNames)
              {
                  // Find the corresponding coin GameObject by name and add it to the collectedCoins set
                  GameObject coin = allCoins.Find(obj => obj.name == coinName);
                  if (coin != null)
                  {
                      collectedCoins.Add(coin);
                      coin.SetActive(false); // Ensure collected coins are deactivated
                  }
              }
          }
          else
          {
              Debug.Log("No data");
              // Handle the case when there is no saved collected coin data
              // You can choose to initialize collectedCoins or perform other actions here.
          }
      }


    // Call this function to save the player's position
    public void SavePlayerPosition(Vector2 position)
    {
        PlayerPrefs.SetFloat("PlayerX", position.x);
        PlayerPrefs.SetFloat("PlayerY", position.y);
        PlayerPrefs.Save();
    }

    // Call this function to load the player's position
    public void LoadPlayerPosition()
    {
        if (PlayerPrefs.HasKey("PlayerX") && PlayerPrefs.HasKey("PlayerY"))
        {
            float playerX = PlayerPrefs.GetFloat("PlayerX");
            float playerY = PlayerPrefs.GetFloat("PlayerY");

            Vector2 playerPosition = new Vector2(playerX, playerY);
            player.transform.position = playerPosition;
        }
    }


}

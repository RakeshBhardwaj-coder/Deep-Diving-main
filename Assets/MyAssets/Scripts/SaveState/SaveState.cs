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
    void Start()
    {
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
/*        LoadCollectedCoins();*/
       
        
    }
    void LoadGame()
    {
        LoadCollectedCoins();

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

    /*
      // Call this function to save the player's position
      public static void SavePlayerPosition(Vector3 position)
      {
          PlayerPrefs.SetFloat("PlayerX", position.x);
          PlayerPrefs.SetFloat("PlayerY", position.y);
          PlayerPrefs.SetFloat("PlayerZ", position.z);
          PlayerPrefs.Save();
      }

      // Call this function to load the player's position
      public static Vector3 LoadPlayerPosition()
      {
          float playerX = PlayerPrefs.GetFloat("PlayerX");
          float playerY = PlayerPrefs.GetFloat("PlayerY");
          float playerZ = PlayerPrefs.GetFloat("PlayerZ");

          Vector3 playerPosition = new Vector3(playerX, playerY, playerZ);
          return playerPosition;
      }*/


}

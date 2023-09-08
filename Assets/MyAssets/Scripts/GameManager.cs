using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float normalMoveSpeed; // Adjust this value to control movement speed
    public float boostedMoveSpeed; // Speed when Shift is held
    public bool isBoosted = false;
    public GameObject gameOverPanel;
    public GameObject gameCanvas;
    public GameObject gameTutorialCanvas;
    private bool isGameOver = false;
    public Animator pauseGameAnim;
    public bool isWinnedGame=false;


    //Singlton
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }

    public int playerMaxHeart=4;
    public bool isAttack = true;


    public void GameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
        gameCanvas.SetActive(false);
        gameTutorialCanvas.SetActive(false);
    }
    public void PauseGame()
    {
        pauseGameAnim.SetBool("isPaused", true);
      /*  Time.timeScale = Time.timeScale == 0 ? 1 : 0;*/ // same button for pause and unPause
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseGameAnim.SetBool("isPaused", false);

    }

    public void RestartGame()
    {
        // Reset game variables and scene
        isGameOver = false;
        gameOverPanel.SetActive(false);
        gameCanvas.SetActive(true);
        gameTutorialCanvas.SetActive(true);
        Time.timeScale = 1f;

        SceneManager.LoadScene("Game");
        // Implement code to restart the game (e.g., reload the scene)
    }
 
    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void ReduceHealth(int damage)
    {
        PlayerAnimation.Instance.HurtAnimation();
        HealthManager.Instance.ReduceHealth(damage);
        SoundManager.Instance.PlayHitttingAudio(); //sound
        isAttack = false;

    }
    void OnApplicationPause(bool isApplicationPaused)
    {
        if (isApplicationPaused)
        {
            // The game is being paused.
            PauseGame();
          /*  SaveGameState();*/
        }
        else
        {
            // The game is being resumed.
          /*  LoadGameState();*/
            Resume();
        }
    }

   /* private void SaveGameState()
    {
        // Save relevant game state data using PlayerPrefs or another method.
        PlayerPrefs.SetInt("Score", yourScore);
        PlayerPrefs.SetFloat("PlayerPositionX", playerTransform.position.x);
        // Add more data as needed.
        PlayerPrefs.Save();
    }

    private void LoadGameState()
    {
        // Load and restore the saved game state data.
        yourScore = PlayerPrefs.GetInt("Score", 0);
        float playerPosX = PlayerPrefs.GetFloat("PlayerPositionX", 0f);
        playerTransform.position = new Vector3(playerPosX, playerTransform.position.y, playerTransform.position.z);
        // Load more data as needed.
    }*/
    public void Boost(bool boost)
    {
        isBoosted = boost;
    }

}

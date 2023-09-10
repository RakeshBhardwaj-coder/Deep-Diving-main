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

    //save the game state
    [System.Serializable]
    public class GameState
    {
        // Define variables to save the game state
        public int playerScore;
        public bool isGamePaused;
        // Add any other variables you want to save here
    }
    private GameState currentGameState;


    public void GameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
        gameCanvas.SetActive(false);
        gameTutorialCanvas.SetActive(false);

        SaveState.Instance.DeleteKeys();

    }
    public void PauseGame()
    {
        pauseGameAnim.SetBool("isPaused", true);
        /*  Time.timeScale = Time.timeScale == 0 ? 1 : 0;*/ // same button for pause and unPause
        
        //just for check
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
    private void OnApplicationPause(bool isPaused)
    {
        if (isPaused)
        {
            SaveState.Instance.SavePlayerPosition(SaveState.Instance.player.transform.position);
        }
    }

    public void Boost(bool boost)
    {
        isBoosted = boost;
    }

}

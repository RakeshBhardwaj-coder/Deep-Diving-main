using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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

}

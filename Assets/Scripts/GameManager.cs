using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private string endSceneName = "EndScreen";

    private int enemiesKilled = 0;
    [SerializeField] private int enemiesRequired = 5;



    void Awake()
    {
        instance = this;
    }

    public void ShowGameOver()
    {
        Debug.Log("GAME OVER");

        if (gameOverPanel == null)
        {
            Debug.LogError("Game Over Panel is NOT assigned!");
            return;
        }

        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    
    void LoadEndScreen()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(endSceneName);
    }

    public void EnemyKilled()
    {
        enemiesKilled++;

        Debug.Log("Enemies killed: " + enemiesKilled);

        if (enemiesKilled >= enemiesRequired)
        {
            Debug.Log("Boss defeated!");

           

            Invoke("LoadEndScreen", 2f);
        }
    }

    }

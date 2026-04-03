using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static bool isGamePaused = false;
    public static bool isGameOver = false;
    public float fallThreshold = -3f;
    public PlayerJump playerJump;

    public float baseSpeed = 1.5f;
    public float speedIncrease = 0.5f;
    public int coinsPerLevel = 10;
    public float currentSpeed;

    void Awake()
    {
        instance = this;
        currentSpeed = baseSpeed;
        isGameOver = false;
        isGamePaused = false;
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (!isGameOver && playerJump != null && playerJump.transform.position.y < fallThreshold)
        {
            GameOver(playerJump);
        }
    }
    
    public void UpdateSpeed(int coins)
    {
        if (coins > 80)
        {
            coins = 80;
        }
        int level = coins / coinsPerLevel;
        currentSpeed = baseSpeed + (level * speedIncrease);
    }

    public void TogglePauseGame()
    {
        if (isGamePaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        isGamePaused = true;
        ScreenManager.Instance.ShowPopup(ScreenType.PauseGame);
        Debug.Log("Game Paused");
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        isGamePaused = false;
        ScreenManager.Instance.HidePopup(ScreenType.PauseGame);
        Debug.Log("Game Resumed");
    }

    public void LowGravity()
    {
        Physics2D.gravity = new Vector2(0, -5.7f);
    }

    public void MediumGravity()
    {
        Physics2D.gravity = new Vector2(0, -9.81f);
    }

    public void HighGravity()
    {
        Physics2D.gravity = new Vector2(0, -13f);
    }

    public void GameOver(PlayerJump player)
    {
        if (isGameOver)
            return;

        isGameOver = true;

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = 0f;
        rb.simulated = false;

        ScreenManager.Instance.ShowPopup(ScreenType.GameOver);
        Debug.Log("Game Over");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        Debug.Log(Time.timeScale);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
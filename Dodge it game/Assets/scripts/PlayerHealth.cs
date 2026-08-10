using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int lives;
    public TextMeshProUGUI healthText;

    void Start()
    {
        SetLivesForLevel();
        UpdateUI();
    }

    void SetLivesForLevel()
    {
        int levelIndex = SceneManager.GetActiveScene().buildIndex;

        // Level 1
        if (levelIndex == 1)
        {
            lives = 5;
        }
        // Level 2
        else if (levelIndex == 2)
        {
            lives = 4;
        }
        // Any other level (fallback)
        else
        {
            lives = 4;
        }
    }

    public void TakeDamage()
    {
        lives--;
        if (lives < 0) lives = 0;

        UpdateUI();

        if (lives <= 0)
            GameOver();
    }

    void UpdateUI()
    {
        if (healthText != null)
            healthText.text = "Lives: " + lives;
    }

    void GameOver()
    {
        GameOverManager gm = FindFirstObjectByType<GameOverManager>();
        if (gm != null)
        {
            gm.ShowGameOver();
        }
    }
}

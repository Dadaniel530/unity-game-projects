using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public int winScore = 5;

    public TextMeshProUGUI tokenText;

    private bool levelLoading = false; // prevents double loading

    void Start()
    {
        ResetTokens();   // 👈 IMPORTANT
        UpdateUI();
    }

    void ResetTokens()
    {
        score = 0;
        levelLoading = false;
    }

    public void AddToken()
    {
        if (levelLoading) return;

        score++;
        if (score > winScore) score = winScore;

        UpdateUI();
        Debug.Log("Tokens: " + score);

        if (score >= winScore)
        {
            levelLoading = true;
            LoadNextLevel();
        }
    }

    public void RemoveToken()
    {
        if (levelLoading) return;

        score--;
        if (score < 0) score = 0;

        UpdateUI();
        Debug.Log("Tokens: " + score);
    }

    void UpdateUI()
    {
        if (tokenText != null)
        {
            tokenText.text = "Tokens: " + score + " / " + winScore;
        }
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex + 1,
            LoadSceneMode.Single
        );
    }
}

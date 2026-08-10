using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PenguinGameLogic : MonoBehaviour
{
    public int score = 20;
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public float timeRemaining = 90f;
    public Transform respawnPoint;
    public GameObject gameOverPanel;
    public TMP_Text gameOverText;
    public Button restartButton;

    public GameObject gameHUD;     
    public GameObject mainMenu;     

    private bool isGameOver = false;
    private bool timerRunning = false;
    private bool gameStarted = false;

    void Start()
    {
        
        if (gameHUD != null)
            gameHUD.SetActive(false);

        if (mainMenu != null)
            mainMenu.SetActive(true);

        UpdateScoreText();
        UpdateTimerText();

        
    }

    void Update()
    {
        if (!gameStarted || isGameOver)
            return;

        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerText();
            }
            else
            {
                timeRemaining = 0;
                timerRunning = false;
                GameOver("Time's up!");
            }
        }
    }

    // Called when the Start button is clicked
    public void StartGame()
    {

        //PenguinSoundManager.instance.PlayMusic(PenguinSoundManager.instance.gameStartMusic);
        gameStarted = true;
        timerRunning = true;
        

        if (mainMenu != null)
            mainMenu.SetActive(false); // hide menu
        if (gameHUD != null)
            gameHUD.SetActive(true);   

       
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = $"Time: {minutes:00}:{seconds:00}";
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ice Cube"))
        {
            PenguinSoundManager.instance.PlaySFX(PenguinSoundManager.instance.hitIceClip);
            score -= 5;
            if (score < 0)
            {
                score = 0;
            }

            UpdateScoreText(); 

            if (score <= 0)
            {
                GameOver("Penguin froze!");
                PenguinSoundManager.instance.PlaySFX(PenguinSoundManager.instance.timerEndClip);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Holes"))
        {
            PenguinSoundManager.instance.PlaySFX(PenguinSoundManager.instance.fallHoleClip);
            transform.position = respawnPoint.position;
            Debug.Log("Penguin fell into a hole! Respawning...");
        }

        if (other.CompareTag("Goal"))
        {
            PenguinSoundManager.instance.PlaySFX(PenguinSoundManager.instance.goalClip);
            GameOver("You got the goldfish!");
        }
    }

    void GameOver(string message)
    {
        isGameOver = true;
        timerRunning = false;

        // stop penguin movement
        var controller = GetComponent<PenguinController>();
        if (controller) controller.enabled = false;

        // freeze physics
        var rb = GetComponent<Rigidbody>();
        if (rb) rb.isKinematic = true;

        // show Game Over UI
        gameOverText.text = message;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        PenguinSoundManager.instance.PlaySFX(PenguinSoundManager.instance.timerEndClip);

        restartButton.onClick.RemoveAllListeners();
        restartButton.onClick.AddListener(() =>
        {
            PenguinSoundManager.instance.PlaySFX(PenguinSoundManager.instance.buttonClickClip); 
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
    }
}

using UnityEngine;
using TMPro;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject howToPlayPanel;
    public TextMeshProUGUI countdownText;

    void Start()
    {
        Time.timeScale = 0f;

        startPanel.SetActive(true);
        howToPlayPanel.SetActive(false);

        if (countdownText != null)
            countdownText.gameObject.SetActive(false);
    }

    public void StartButton()
    {
        Debug.Log("START BUTTON CLICKED");

        startPanel.SetActive(false);
        howToPlayPanel.SetActive(false); // 👈 THIS IS KEY

        StartCoroutine(Countdown());
    }


    IEnumerator Countdown()
    {
        countdownText.gameObject.SetActive(true);

        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSecondsRealtime(1f);
        }

        countdownText.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ShowHowToPlay()
    {
        startPanel.SetActive(false);
        howToPlayPanel.SetActive(true);
    }

    public void CloseHowToPlay()
    {
        howToPlayPanel.SetActive(false);
        startPanel.SetActive(true);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject instructionsPanel;
    //public GameObject gameElements;

    public void StartGame()
    {
        PenguinSoundManager.instance.PlaySFX(PenguinSoundManager.instance.buttonClickClip); 
       // PenguinSoundManager.instance.PlayMusic(PenguinSoundManager.instance.gameStartMusic);
        mainMenuPanel.SetActive(false);
        instructionsPanel.SetActive(false);
        //gameElements.SetActive(true);
    }

    public void ShowInstructions()
    {
        PenguinSoundManager.instance.PlaySFX(PenguinSoundManager.instance.buttonClickClip); 
        mainMenuPanel.SetActive(false);
        instructionsPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        PenguinSoundManager.instance.PlaySFX(PenguinSoundManager.instance.buttonClickClip); 
        instructionsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}

using UnityEngine;

public class PenguinSoundManager : MonoBehaviour
{
    public static PenguinSoundManager instance;

    [Header("Audio Sources")]
    
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Clips")]
    public AudioClip slideClip;
    public AudioClip hitIceClip;
    public AudioClip fallHoleClip;
    public AudioClip goalClip;
    public AudioClip timerEndClip;
    public AudioClip tickClip;
    public AudioClip scoreDownClip;
    public AudioClip powerUpClip;
    public AudioClip buttonClickClip;
    public AudioClip gameStartMusic;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip) sfxSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip && musicSource.clip != clip)
        {
            musicSource.clip = clip;
            musicSource.loop = true;
            musicSource.Play();
        }
    }
}

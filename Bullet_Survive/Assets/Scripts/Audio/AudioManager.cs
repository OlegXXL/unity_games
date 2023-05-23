using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioClip mainMenuMusic;
    [SerializeField] private AudioClip gameMusic;
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private AudioClip buttonSound;
    [SerializeField] private float musicVolume = 0.5f;
    [SerializeField] private float soundVolume = 0.5f;

    private AudioSource musicSource;
    private AudioSource soundSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        musicSource = gameObject.AddComponent<AudioSource>();
        soundSource = gameObject.AddComponent<AudioSource>();

        musicSource.loop = true;
        musicSource.volume = musicVolume;
        soundSource.volume = soundVolume;

        SceneManager.activeSceneChanged += OnSceneChanged;
        UpdateMusicForScene(SceneManager.GetActiveScene().name);
    }

    private void OnSceneChanged(Scene previousScene, Scene newScene)
    {
        UpdateMusicForScene(newScene.name);
    }

    private void UpdateMusicForScene(string sceneName)
    {
        if (sceneName == "MainMenu")
        {
            musicSource.clip = mainMenuMusic;
        }
        else
        {
            musicSource.clip = gameMusic;
        }

        musicSource.Play();
    }

    public void PlayShootSound()
    {
        soundSource.PlayOneShot(shootSound);
    }

    public void PlayButtonSound()
    {
        soundSource.PlayOneShot(buttonSound);
    }

    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= OnSceneChanged;
    }
}

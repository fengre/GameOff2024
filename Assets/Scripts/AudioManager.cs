using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {get; private set;}

    [Header("Audio Info")]
    public AudioClip mainMenuMusic;
    public AudioClip gameSceneMusic;
    public AudioClip endSceneMusic;

    private AudioSource audioSource;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.playOnAwake = false;
        audioSource.volume = 0.5f;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        PlayMusicForCurrentScene();
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForCurrentScene();
    }

    public void PlayMusicForCurrentScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        AudioClip selectedTrack = null;

        switch (sceneName)
        {
            case "MainMenu":
                selectedTrack = mainMenuMusic;
                break;
            case "OpeningScene":
                selectedTrack = gameSceneMusic;
                break;
            case "EndScene":
                selectedTrack = endSceneMusic;
                break;
        }

        if(selectedTrack != null && audioSource.clip != selectedTrack)
        {
            audioSource.clip = selectedTrack;
            audioSource.Play();
        }
    }

    public void StopMusic()
    {
        if(audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void SetVolume(float volume)
    {
        if(audioSource != null)
        {
            audioSource.volume = Mathf.Clamp01(volume);
        }
    }

}

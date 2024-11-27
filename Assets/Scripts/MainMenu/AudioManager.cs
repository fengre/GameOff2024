using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {get; private set;}
    private AudioSource musicSource;
    private AudioSource ambientSource;
    private AudioSource sfxSource;

    [Header("Audio Info")]
    public AudioClip mainMenuMusic;
    public AudioClip startSceneMusic;

    [Header("Ambient Sounds")]
    public AudioClip riverAmbientSound;

    [Header("SFX")]
    public AudioClip startButtonSFX;
    public AudioClip backpackOpenSFX;
    public AudioClip backpackCloseSFX;
    public AudioClip onClickSFX;

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

        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;
        musicSource.playOnAwake = false;
        musicSource.volume = 1.0f;

        ambientSource = gameObject.AddComponent<AudioSource>();
        ambientSource.loop = true;
        ambientSource.playOnAwake = false;
        ambientSource.volume = 0.5f;

        sfxSource = gameObject.AddComponent<AudioSource>();
        sfxSource.loop = false;
        sfxSource.playOnAwake = false;
        sfxSource.volume = 1.0f;

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

        AudioClip selectedMusic = null;
        AudioClip selectedAmbient = null;

        switch (sceneName)
        {
            case "MainMenu":
                selectedMusic = mainMenuMusic;
                break;
            case "StartScene":
                selectedMusic = startSceneMusic;
                break;
            case "River":
            case "Lake":
                selectedAmbient = riverAmbientSound;
                break;
        }

        if(selectedMusic != null && musicSource.clip != selectedMusic)
        {
            musicSource.clip = selectedMusic;
            musicSource.Play();
        }

        if (selectedAmbient != null && ambientSource.clip != selectedAmbient)
        {
            ambientSource.clip = selectedAmbient;
            ambientSource.Play();
        }
        else if (selectedAmbient == null)
        {
            //Stop ambient if none is set to scene
            ambientSource.Stop();
        }
    }
    public void PlaySFX(AudioClip clip)
    {
        if (sfxSource != null && clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }

    public void StopMusic()
    {
        if(musicSource != null)
        {
            musicSource.Stop();
        }

        if(ambientSource != null)
        {
            ambientSource.Stop();
        }
    }

    public void SetVolume(float volume)
    {
        if(musicSource != null)
        {
            musicSource.volume = Mathf.Clamp01(volume);
        }
    }

    public void SetAmbientVolume(float volume)
    {
        if (ambientSource != null)
        {
            ambientSource.volume = Mathf.Clamp01(volume);
        }
    }

    public void SetSFXVolume(float volume)
{
    if (sfxSource != null)
    {
        sfxSource.volume = Mathf.Clamp01(volume);
    }
}


    public float GetVolume()
    {
        return musicSource != null ? musicSource.volume : 0f;
    }

}

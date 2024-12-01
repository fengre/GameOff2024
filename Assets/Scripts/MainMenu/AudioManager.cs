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
    public AudioClip endSceneMusic;

    [Header("Ambient Sounds")]
    public AudioClip riverAmbientSound;
    public AudioClip lensAmbientSound;

    [Header("SFX")]
    public AudioClip startButtonSFX;
    public AudioClip backpackOpenSFX;
    public AudioClip backpackCloseSFX;
    public AudioClip onClickSFX;
    public AudioClip dialogueClickSFX;
    public AudioClip viewSecretSFX;

    private const string MUSIC_VOLUME_KEY = "MusicVolume";
    private const string AMBIENT_VOLUME_KEY = "AmbientVolume";
    private const string SFX_VOLUME_KEY = "SFXVolume";

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
        musicSource.volume = PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY, 1.0f);

        ambientSource = gameObject.AddComponent<AudioSource>();
        ambientSource.loop = true;
        ambientSource.playOnAwake = false;
        ambientSource.volume = PlayerPrefs.GetFloat(AMBIENT_VOLUME_KEY, 0.5f);

        sfxSource = gameObject.AddComponent<AudioSource>();
        sfxSource.loop = false;
        sfxSource.playOnAwake = false;
        sfxSource.volume = PlayerPrefs.GetFloat(SFX_VOLUME_KEY, 1.0f);

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
            case "EndScene":
                selectedMusic = endSceneMusic;
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

    #region Lens Ambience
    public void PlayLensAmbientSound()
    {
        if (ambientSource != null && lensAmbientSound != null)
        {
            ambientSource.clip = lensAmbientSound;
            ambientSource.loop = true;
            ambientSource.Play();
        }
    }

    public void StopLensAmbientSound()
    {
        if (ambientSource != null && ambientSource.clip == lensAmbientSound)
        {
            ambientSource.Stop();
        }
    }
    #endregion

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

    public void SetMusicVolume(float volume)
    {
        if (musicSource != null)
        {
            musicSource.volume = Mathf.Clamp01(volume);
            PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, volume);
        }
    }

    public void SetAmbientVolume(float volume)
    {
        if (ambientSource != null)
        {
            ambientSource.volume = Mathf.Clamp01(volume);
            PlayerPrefs.SetFloat(AMBIENT_VOLUME_KEY, volume);
        }
    }

    public void SetSFXVolume(float volume)
    {
        if (sfxSource != null)
        {
            sfxSource.volume = Mathf.Clamp01(volume);
            PlayerPrefs.SetFloat(SFX_VOLUME_KEY, volume);
        }
    }


    public float GetMusicVolume() => musicSource != null ? musicSource.volume : 0f;
    public float GetAmbientVolume() => ambientSource != null ? ambientSource.volume : 0f;
    public float GetSFXVolume() => sfxSource != null ? sfxSource.volume : 0f;
}

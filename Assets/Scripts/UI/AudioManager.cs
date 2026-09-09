using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {get; private set;}
    [SerializeField] public AudioSource musicSource;
    [SerializeField] public AudioSource sfxSource;

    [SerializeField] private SettingsControl SettingsControl;
    //private float value = SettingsControl.value("Volume");
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        PlayerPrefs.GetFloat("SVolume");
    }

    public void PlayMusicWithLoop(AudioClip musicClip)
    {
        musicSource.loop = true;
        //musicSource.Stop();
        musicSource.clip = musicClip;
        //musicSource.Play();
    }/*

    public void PlayMusicNoLoop(AudioClip musicClip)
    {
        musicSource.Stop();
        musicSource.clip = musicClip;
        musicSource.Play();
        musicSource.loop = false;
    }*/

    public void PlaySFX(AudioClip sfxClip)
    {
        sfxSource.PlayOneShot(sfxClip);
    }

    public void MuteSound()
    {
        sfxSource.mute = true;
    }

    public void UnMuteSound()
    {
        sfxSource.mute = false;
    }
    
    public void MuteMusic()
    {
        musicSource.mute = true;
    }

    public void UnMuteMusic()
    {
        musicSource.mute = false;
    }
}

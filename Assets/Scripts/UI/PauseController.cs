using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button playButton;
    [SerializeField] private Button mMenu;
    [SerializeField] private Button quitButton;
    [SerializeField] private Toggle activeSound;
    [SerializeField] private Toggle activeMusic;
    [SerializeField] private Slider sound;
    [SerializeField] private Slider music;
    
    [SerializeField] private GameFlowManager  gameFlowManager;
    [SerializeField] private AudioManager audioManager;

    [SerializeField] private AudioMixer sMixer;
    [SerializeField] private SoundMixMode sMixMode;
    public enum SoundMixMode
    {LinearSourceVolume, LinearMixVolume, LogMixVolume}
    public void OnChangeSoundSlider(float Value)
    {
        switch(sMixMode)
        {
            case SoundMixMode.LinearSourceVolume:
                audioManager.sfxSource.volume = Value;
                break;
            case SoundMixMode.LinearMixVolume:
                sMixer.SetFloat("SVolume", -80 + Value * 100);
                break;
            case SoundMixMode.LogMixVolume:
                sMixer.SetFloat("SVolume", Mathf.Log10(Value) * 20);
                break;
        }

        PlayerPrefs.SetFloat("SVolume", Value);
    }

    [SerializeField] private AudioMixer mMixer;
    [SerializeField] private MusicMixMode mMixMode;
    public enum MusicMixMode
    {LinearSourceVolume, LinearMixVolume, LogMixVolume}
    public void OnChangeMusicSlider(float Value)
    {
        switch(mMixMode)
        {
            case MusicMixMode.LinearSourceVolume:
                audioManager.musicSource.volume = Value;
                break;
            case MusicMixMode.LinearMixVolume:
                mMixer.SetFloat("MVolume", -80 + Value * 100);
                break;
            case MusicMixMode.LogMixVolume:
                mMixer.SetFloat("MVolume", Mathf.Log10(Value) * 20);
                break;
        }

        PlayerPrefs.SetFloat("MVolume", Value);
    }

    private void Awake()
    {
        audioManager = AudioManager.Instance;
        pauseMenu.SetActive(false);
        pauseButton.onClick.AddListener(OnPausePressed);
        playButton.onClick.AddListener(OnPlayPressed);
        mMenu.onClick.AddListener(OnMMenuPressed);
        quitButton.onClick.AddListener(OnQuitPressed);
        activeSound.onValueChanged.AddListener(OnSoundToggled);
        activeMusic.onValueChanged.AddListener(OnMusicToggled);

        sMixer.SetFloat("SVolume", Mathf.Log10(PlayerPrefs.GetFloat("SVolume", 1) * 20));
        mMixer.SetFloat("MVolume", Mathf.Log10(PlayerPrefs.GetFloat("MVolume", 1) * 20));
    }

    public void OnPausePressed()
    {
        gameFlowManager.Pause();
        pauseMenu.SetActive(true);
    }

    public void OnPlayPressed()
    {
        gameFlowManager.Play();
        pauseMenu.SetActive(false);
    }

    public void OnMMenuPressed()
    {
        gameFlowManager.ChageScene("A-Main-Menu");
    }

    public void OnQuitPressed()
    {
        gameFlowManager.Quit();
    }

    public void OnSoundToggled(bool isOn)
    {
        if (isOn)
            audioManager.UnMuteSound();
        else
            audioManager.MuteSound();
    }
    
    public void OnMusicToggled(bool isOn)
    {
        if (isOn)
            audioManager.UnMuteMusic();
        else
            audioManager.MuteMusic();
    }
}

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsControl : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private Slider sound;
    [SerializeField] private Slider music;
    [SerializeField] private Button mMenu;
    [SerializeField] private Button quitButton;

    [SerializeField] private GameFlowManager gameFlowManager;
    [SerializeField] private AudioManager audioManager;

    [SerializeField] private AudioMixer sMixer;
    [SerializeField] private SoundMixMode sMixMode;


    public enum SoundMixMode
    { LinearSourceVolume, LinearMixVolume, LogMixVolume }
    public void OnChangeSoundSlider(float Value)
    {
        switch (sMixMode)
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
    { LinearSourceVolume, LinearMixVolume, LogMixVolume }
    public void OnChangeMusicSlider(float Value)
    {
        switch (mMixMode)
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

    private void Start()
    {
        audioManager = AudioManager.Instance;
        settingsMenu.SetActive(true);
        mMenu.onClick.AddListener(OnMMenuPressed);
        quitButton.onClick.AddListener(OnQuitPressed);

        sMixer.SetFloat("SVolume", Mathf.Log10(PlayerPrefs.GetFloat("SVolume", 1) * 20));
        mMixer.SetFloat("MVolume", Mathf.Log10(PlayerPrefs.GetFloat("MVolume", 1) * 20));
    }

    public void OnMMenuPressed()
    {
        gameFlowManager.ChageScene("A-Main-Menu");
    }

    public void OnQuitPressed()
    {
        gameFlowManager.Quit();
    }
}
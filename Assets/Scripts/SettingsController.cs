using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private Scrollbar sound;
    [SerializeField] private Button mMenu;
    [SerializeField] private Button quitButton;
    
    [SerializeField] private GameFlowManager  gameFlowManager ;
    [SerializeField] private AudioManager audioManager;

    private void Start()
    {
        settingsMenu.SetActive(true);
        sound.onValueChanged.AddListener(_ => OnSoundPressed());
        mMenu.onClick.AddListener(OnMMenuPressed);
        quitButton.onClick.AddListener(OnQuitPressed);
    }

    public void OnSoundPressed()
    {
        
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

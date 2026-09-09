using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private Button playButton;
    [SerializeField] private Button controls;
    [SerializeField] private Button settings;
    [SerializeField] private Button credits;
    [SerializeField] private Button quitButton;

    [SerializeField] private GameFlowManager  gameFlowManager;

    private void Start()
    {
        mainMenu.SetActive(true);
        playButton.onClick.AddListener(OnPlayPressed);
        settings.onClick.AddListener(OnSettingsPressed);
        controls.onClick.AddListener(OnControlsPressed);
        credits.onClick.AddListener(OnCreditsPressed);
        quitButton.onClick.AddListener(OnQuitPressed);
    }

    public void OnPlayPressed()
    {
        gameFlowManager.ChageScene("F-Lore");
    }

    public void OnControlsPressed()
    {
        gameFlowManager.ChageScene("E-Controls");
    }

    public void OnSettingsPressed()
    {
        gameFlowManager.ChageScene("C-Settings");
    }

    public void OnCreditsPressed()
    {
        gameFlowManager.ChageScene("D-Credits");
    }

    public void OnQuitPressed()
    {
        gameFlowManager.Quit();
    }
}
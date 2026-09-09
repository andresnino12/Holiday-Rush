using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class LoreController : MonoBehaviour
{
    [SerializeField] private GameObject loreMenu;
    [SerializeField] private Button playButton;
    [SerializeField] private Button mMenu;
    [SerializeField] private Button quitButton;
    [SerializeField] private GameFlowManager  gameFlowManager;

    private void Awake()
    {
        playButton.onClick.AddListener(OnPlayPressed);
        mMenu.onClick.AddListener(OnMMenuPressed);
        quitButton.onClick.AddListener(OnQuitPressed);
    }
    public void OnPlayPressed()
    {
        gameFlowManager.ChageScene("2-TEST-1");// OJO, ES PROVICIONAL
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
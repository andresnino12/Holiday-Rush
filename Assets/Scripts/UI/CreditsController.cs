using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreditsController : MonoBehaviour
{
    [SerializeField] private GameObject creditsMenu;
    [SerializeField] private Button mMenu;
    [SerializeField] private Button quitButton;
    
    [SerializeField] private GameFlowManager gameFlowManager;

    private void Start()
    {
        creditsMenu.SetActive(true);
        mMenu.onClick.AddListener(OnMMenuPressed);
        quitButton.onClick.AddListener(OnQuitPressed);
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

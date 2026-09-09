using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FinishScreen : MonoBehaviour
{
    public TMP_Text collectionState;
    private static FinishScreen instance;
    [SerializeField] private GameObject Win;
    [SerializeField] private GameObject Fail;
    [SerializeField] private Button playButton;
    [SerializeField] private Button mMenu;
    [SerializeField] private Button quitButton;
    [SerializeField] private GameFlowManager gameFlowManager;
    public bool tiempoFinalizado;
    public bool itemsCompletos;
    public bool itemsIncompletos;
    void Awake()
    {
        instance = this;

        Win.SetActive(false);
        Fail.SetActive(false);
        playButton.onClick.AddListener(OnRetryPressed);
        mMenu.onClick.AddListener(OnMMenuPressed);
        quitButton.onClick.AddListener(OnQuitPressed);
        playButton.gameObject.SetActive(false);
        mMenu.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
    }
    void Update()
    {
        if (itemsCompletos == true)
        {
            Win.SetActive(true);
            Activacion();
        }
        else if (tiempoFinalizado == true && itemsIncompletos == true)
        {
            Fail.SetActive(false);
            Activacion();
        }
    }

    public static void Log(string estado)
    {
        if (instance != null & instance.collectionState != null)
        {
            instance.collectionState.text = estado;
        }
        Debug.Log(estado);
    }

    void Activacion()
    {
        playButton.gameObject.SetActive(true);
        mMenu.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }

    public void OnRetryPressed()
    {
        gameFlowManager.ChageScene("F-Lore");
    }

    public void OnMMenuPressed()
    {
        gameFlowManager.ChageScene("A-Main-Menu");
    }

    public void OnQuitPressed()
    {
        gameFlowManager.Quit();
    }

    public void TiempoFinalizado()
    {
        tiempoFinalizado = true;
    }

    public void ObjetosCompletos()
    {
        itemsCompletos = true;
    }
    public void ObjetosIncompletos()
    {
        itemsIncompletos = true;
    }
}

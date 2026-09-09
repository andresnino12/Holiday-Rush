using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using NUnit.Framework;

public class GameFlowManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public bool IsPaused { get; private set; }
    void Start()
    {
        Play();
    }

    public void Pause()
    {
        if (IsPaused) return;
        IsPaused = true;
        Time.timeScale = 0f;
    }

    public void Play()
    {
        if (!IsPaused) return;
        IsPaused = false;
        Time.timeScale = 1f;
    }

    public void Quit()//QuitToDesktop() o QuitToMainMenu() en el futuro
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    public void ChageScene(string nameNewScene)
    {
        SceneManager.LoadScene(nameNewScene);
    }
    
    public void RestartActualScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

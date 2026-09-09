using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    public FinishScreen finishScreen;
    public static CountDown Instance;
    public float timeRemaining = 60f;
    public TMP_Text timerText;
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay(timeRemaining);
        }
        else
        {
            timeRemaining = 0;
            UpdateTimerDisplay(timeRemaining);
            TimeIsUp();
        }
    }
    void UpdateTimerDisplay(float time)
    {
        int seconds = Mathf.CeilToInt(time);
        timerText.text = seconds.ToString();
    }
    void TimeIsUp()
    {
         finishScreen.TiempoFinalizado();
    }
}

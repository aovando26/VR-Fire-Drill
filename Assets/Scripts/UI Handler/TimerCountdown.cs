using TMPro;
using UnityEngine;

public class TimerCountdown : MonoBehaviour
{
    public TextMeshProUGUI timerText; 
    public void StartTimer()
    {
        gameObject.SetActive(true);
        timerText.text = "Timer Start";
    }
}

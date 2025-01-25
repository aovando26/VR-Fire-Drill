using TMPro;
using UnityEngine;

public class TimerCountdown : MonoBehaviour
{

    public float timerCountdown = 120f;

    private void Update()
    {
        if (timerCountdown > 0)
        {
            timerCountdown -= Time.deltaTime;
        }

        else if (timerCountdown < 0)
        {
            timerText.text = "End Game";
        }

        int minutes = Mathf.FloorToInt(timerCountdown / 60);
        int seconds = Mathf.FloorToInt(timerCountdown % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public TextMeshProUGUI timerText; 
    public void StartTimer()
    {
        gameObject.SetActive(true);
    }
}

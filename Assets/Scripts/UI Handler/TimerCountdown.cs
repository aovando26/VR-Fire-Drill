using TMPro;
using UnityEngine;

public class TimerCountdown : MonoBehaviour
{
    public GameObject bar;
    public float timerCountdown;

    private void Update()
    {
        if (timerCountdown > 0)
        {
            timerCountdown -= Time.deltaTime;
        }
        else if (timerCountdown <= 0)
        {
            timerText.text = "Time's up!";
            GameManager.Instance.GameOver();
        }

        int minutes = Mathf.FloorToInt(timerCountdown / 60);
        int seconds = Mathf.FloorToInt(timerCountdown % 60);
        
        LeanTween.scaleX(bar, timerCountdown / 300, 0.1f);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public TextMeshProUGUI timerText; 
    public void StartTimer()
    {
        gameObject.SetActive(true);
    }
}

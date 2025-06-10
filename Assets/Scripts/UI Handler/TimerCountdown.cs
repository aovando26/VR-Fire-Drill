using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountdown : MonoBehaviour
{
    public Slider timerSlider;
    public TextMeshProUGUI timerText;

    [SerializeField] private float totalTime = 300f;
    private float currentTime;

    private void Start()
    {
        currentTime = totalTime;

        timerSlider.maxValue = totalTime;
        timerSlider.value = totalTime;

        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;

            if (currentTime < 0)
                currentTime = 0;

            timerSlider.value = currentTime;
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            timerText.text = "Time's up!";
            GameManager.Instance.GameOver();
        }
    }

    public void StartTimer()
    {
        gameObject.SetActive(true);
    }
}

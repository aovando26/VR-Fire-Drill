using UnityEngine;
using System.Collections; 

public class AmberAlert : MonoBehaviour
{
    private AudioSource audioSource;
    public TimerCountdown timerCountdown;

    private void Start()
    {
        StartCoroutine(VibratePhone(5.0f)); 
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator VibratePhone(float delay)
    {
        yield return new WaitForSeconds(delay);
        Handheld.Vibrate(); 
        audioSource.Play();

        yield return new WaitWhile(() => audioSource.isPlaying);
        timerCountdown.StartTimer();
    }
}
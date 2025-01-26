using UnityEngine;
using System.Collections; 

public class AmberAlert : MonoBehaviour
{
    private AudioSource audioSource;
    public TimerCountdown timerCountdown;

    private void Start()
    {
        StartCoroutine(VibratePhone(6.0f)); 
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayNextAudio(4.5f));
    }

    IEnumerator VibratePhone(float delay)
    {
        yield return new WaitForSeconds(delay);
        Handheld.Vibrate(); 
        audioSource.Play();

        yield return new WaitWhile(() => audioSource.isPlaying);
        timerCountdown.StartTimer();
    }

    IEnumerator PlayNextAudio(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameManager.Instance.PlayPlayerAudio(1);
        GameManager.Instance.PlayNPCAudio(0);
    }
}
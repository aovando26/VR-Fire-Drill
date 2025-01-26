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
        StartCoroutine(PlayPlayerAudioIndex(2, 2.0f));
        StartCoroutine(PlayPlayerAudioIndex(3, 10.0f));
        StartCoroutine(PlayPlayerAudioIndex(4, 10.0f));
        StartCoroutine(PlayPlayerAudioIndex(5, 10.0f));
        StartCoroutine(PlayNPCAudioIndex(1, 10.0f));
        StartCoroutine(PlayNPCAudioIndex(2, 10.0f));
        StartCoroutine(PlayNPCAudioIndex(3, 10.0f));
        StartCoroutine(PlayNPCAudioIndex(4, 10.0f));
        StartCoroutine(PlayNPCAudioIndex(5, 10.0f));
        StartCoroutine(PlayNPCAudioIndex(6, 10.0f));
        StartCoroutine(PlayNPCAudioIndex(7, 10.0f));
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

    IEnumerator PlayPlayerAudioIndex(int index, float delay)
    {
        yield return new WaitForSeconds(delay);
        GameManager.Instance.PlayPlayerAudio(index);
    }

    IEnumerator PlayNPCAudioIndex(int index, float delay)
    {
        yield return new WaitForSeconds(delay);
        GameManager.Instance.PlayNPCAudio(index);
    }
}
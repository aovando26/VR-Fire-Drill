using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AmberAlert : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private string mainScene = "Main";
    private bool hasBeenPickedUp;

    private void Start()
    {
        hasBeenPickedUp = false;

        audioSource = GetComponent<AudioSource>();
        Handheld.Vibrate(); // Initial vibration when scene starts
    }

    // Call this when the player picks up the phone (e.g. from XR grab interaction)
    public void OnPhonePickedUp()
    {
        if (!hasBeenPickedUp)
        {
            hasBeenPickedUp = true;
            audioSource.Play();
            StartCoroutine(WaitForAudioToEnd());
        }
    }

    private IEnumerator WaitForAudioToEnd()
    {
        yield return new WaitWhile(() => audioSource.isPlaying);
        SceneManager.LoadScene(mainScene);
    }
}

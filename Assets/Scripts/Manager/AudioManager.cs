using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioClip[] clipsToPlay;

    private AudioSource audioSource;
    private float audioLength;


    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

        private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogWarning("No AudioSource found on the GameObject!");
        }

        PlayAudios();
    }

    public void PlayAudios()
    {
        StartCoroutine("PlayOneByOne");
    }

    IEnumerator PlayOneByOne()
    { 
        yield return null;

        for (int index = 0; index < clipsToPlay.Length; index++)
        { 
            audioSource.clip = clipsToPlay[index];  

            audioSource.Play();

            while (audioSource.isPlaying)
            {
                yield return null;
            }
        }

        Debug.Log("Last Audio is Playing");
    }
}
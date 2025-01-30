using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioClip[] clipsToPlay;
    public AudioClip[] lastClipsToPlay;
    private AudioSource audioSource;
    private float audioLength;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
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

        //Debug.Log("Last Audio is Playing");
    }

    public void PlayLastAudioLines()
    {
        StartCoroutine(PlayLastLines(2.5f));
    }

    IEnumerator PlayLastLines(float delay)
    {
        yield return new WaitForSeconds(delay);

        for (int index = 0; index < lastClipsToPlay.Length; index++)
        {
            audioSource.clip = lastClipsToPlay[index];

            audioSource.Play();

            while (audioSource.isPlaying)
            {
                yield return null;
            }
        }

        Debug.Log("Last Audio is Playing");
    }
}
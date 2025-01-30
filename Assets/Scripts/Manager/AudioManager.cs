using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using System;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0, 1)]
    public float volume = 1;
    [Range(-3, 3)]
    public float pitch = 1;
    public bool loop = false;
    public AudioSource source;

    public Sound()
    {
        volume = 1;
        pitch = 1;
        loop = false;
    }
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioClip[] clipsToPlay;
    public AudioClip[] lastClipsToPlay;
    private AudioSource audioSource;
    private float audioLength;
    public Sound[] sounds;

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

        foreach (Sound s in sounds)
        {
            if (!s.source)
                s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
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

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        s.source.Stop();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class QueuedAudio
{
   public AudioSource Source { get; set; }
   public float Delay { get; set; }
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Toggle[] checklistItems;
    public GameObject pauseMenu;
    public AudioSource[] playerAudioSources;
    public AudioSource[] npcAudioSources;
    public Camera mainCamera;
    int debrisCount = 0;
    bool isPlayingAudio = false;
    readonly Queue<QueuedAudio> audioQueue = new();

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            mainCamera = Camera.main;

            // Fade camera from black to clear
            LeanTween.value(mainCamera.gameObject, 1, 0, 3).setOnUpdate((float value) =>
            {
                mainCamera.backgroundColor = new Color(0, 0, 0, value);
            });
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        bool allItemsChecked = false;

        foreach (Toggle item in checklistItems)
        {
            if (item.isOn)
            {
                allItemsChecked = true;
            }
            else
            {
                allItemsChecked = false;
                break;
            }
        }

        if (allItemsChecked)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        // Fade camera from clear to black
        LeanTween.value(mainCamera.gameObject, 0, 1, 3.5f).setOnUpdate((float value) =>
        {
            mainCamera.backgroundColor = new Color(0, 0, 0, value);
        });
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void CheckDebris()
    {
        debrisCount++;
        if (debrisCount == 2)
        {
            CheckItem(2);
        }
    }

    public void CheckItem(int index)
    {
        checklistItems[index].isOn = true;
    }

    public void OpenPauseMenu()
    {
        bool isActive = true;

        if (pauseMenu.activeSelf)
        {
            isActive = false;
        }
        
        if (isActive)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void PlayPlayerAudio(int index, float delay = 0)
    {
        audioQueue.Enqueue(new QueuedAudio { 
            Source = playerAudioSources[index],
            Delay = delay
        });
        
        if (!isPlayingAudio)
        {
            StartCoroutine(PlayAudioSequentially());
        }
    }

    public void PlayNPCAudio(int index, float delay = 0) 
        {
        audioQueue.Enqueue(new QueuedAudio {
            Source = npcAudioSources[index],
            Delay = delay
        });

        if (!isPlayingAudio)
        {
            StartCoroutine(PlayAudioSequentially());
        }
    }

    private IEnumerator PlayAudioSequentially()
        {
        isPlayingAudio = true;
        
        while (audioQueue.Count > 0)
        {
            QueuedAudio current = audioQueue.Dequeue();
            if (current.Delay > 0)
            {
                yield return new WaitForSeconds(current.Delay);
            }
            current.Source.Play();
            yield return new WaitForSeconds(current.Source.clip.length);
        }
        
        isPlayingAudio = false;
    }       
}
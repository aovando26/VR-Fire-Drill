using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Toggle[] checklistItems;
    public GameObject pauseMenu;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
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
            StartCoroutine(DelayedGameOver(3.5f));
        }
    }

    public void GameOver()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
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

    public void CheckItem(int index)
    {
        checklistItems[index].isOn = true;
    }

    private IEnumerator DelayedGameOver(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameOver();
    }
}
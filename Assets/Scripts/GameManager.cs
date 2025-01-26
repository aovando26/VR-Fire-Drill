using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Toggle[] checklistItems;

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

    public void GameOver()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void CheckItem(int index)
    {
        checklistItems[index].isOn = true;
    }
}
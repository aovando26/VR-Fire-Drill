using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private string preMain = "Pre-Main";
    public GameObject visualCueCanvas;

    //private void Start()
    //{
    //    visualCueCanvas.SetActive(false);
    //}

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == preMain)
        {
            visualCueCanvas.SetActive(true);
        }
    }
    private void OnDestroy()
    {
        // Unregister the callback when this object is destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

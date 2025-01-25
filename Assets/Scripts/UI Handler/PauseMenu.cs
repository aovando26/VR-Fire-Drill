using UnityEngine;

public class PauseMenu : MonoBehaviour
{
  public GameObject pauseMenu;

  void Start() {
      Time.timeScale = 0;
  }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}

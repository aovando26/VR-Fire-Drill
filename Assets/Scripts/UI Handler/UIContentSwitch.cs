using UnityEngine;
using UnityEngine.UI;

public class UIContentSwitch : MonoBehaviour
{
    [Header("Arrow Buttons")]
    public Button rightButton;

    public GameObject rightArrow;

    // array to hold pages 
    public GameObject[] pages;

    // setting current page to index 0
    private int currentPage = 0;

    public GameObject tutorialCanvas;

    // Start is called before the first frame update
    void Start()
    {
        // call methods
        EnableCurrentPage();
        rightButton.onClick.AddListener(EnableNextPage);
    }

    // Display the current page and hide others
    private void EnableCurrentPage()
    {
        // Deactivate all pages first
        foreach (var page in pages)
        {
            page.SetActive(false);
        }

        // Activate the current page - first index 0, then when EnableNextPage method is called 
        // the following index becomes the current
        pages[currentPage].SetActive(true);
        // Debug.Log("Current page is: " + currentPage);
    }

    // Move to the next page
    private void EnableNextPage()
    {
        if (currentPage < pages.Length - 1)
        {
            currentPage++;
            EnableCurrentPage();
        }

        // If we're on the last page, hide the tutorial canvas and arrow
        if (currentPage == pages.Length - 1)
        {
            tutorialCanvas.SetActive(false);
            rightArrow.SetActive(false);
        }
    }

}
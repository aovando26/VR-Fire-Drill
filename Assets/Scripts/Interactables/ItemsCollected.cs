using TMPro;
using UnityEngine;

public class ItemsCollected : MonoBehaviour
{
    public TextMeshProUGUI itemsText;

    void Start()
    {
        // 1. Subscribe our 'UpdateItemsText' method to the event.
        GameManager.Instance.onItemCountChanged += UpdateItemsText;

        // 2. Set the initial text when the game starts (e.g., "0/4").
        UpdateItemsText(0, GameManager.Instance.totalItemsToCollect);

    }

    // It's good practice to unsubscribe when the UI object is destroyed.
    private void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.onItemCountChanged -= UpdateItemsText;
        }
    }

    /// <summary>
    /// This method is called by the GameManager's event.
    /// It receives the counts and updates the text display.
    /// </summary>
    /// <param name="currentCount">The number of items currently collected.</param>
    /// <param name="totalCount">The total number of items needed.</param>
    private void UpdateItemsText(int currentCount, int totalCount)
    {
        if (itemsText != null)
        {
            // Use an interpolated string to format the text neatly.
            itemsText.text = $"Items Collected:<br>{currentCount}/{totalCount}";
        }
    }
}
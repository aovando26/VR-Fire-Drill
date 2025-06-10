using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.Rendering; // Required for using a HashSet
using UnityEngine.Events;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // The total number of unique items the player needs to collect.
    // You can set this to 4 in the Unity Inspector.
    public int totalItemsToCollect = 4;

    // A private set to store the unique items the player has picked up.
    private HashSet<GameObject> _collectedItems = new HashSet<GameObject>();

    public UnityEvent onAllItemsCollected = new UnityEvent();
    public event Action<int, int> onItemCountChanged;
    private void Awake()
    {
        // Standard Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        //DontDestroyOnLoad(gameObject);

        //if (onAllItemsCollected == null)
        //    onAllItemsCollected = new UnityEvent();
    }

    /// <summary>
    /// This public method is called by an item when it's picked up.
    /// </summary>
    /// <param name="itemObject">The item that was picked up.</param>
    public void OnItemPickedUp(GameObject itemObject)
    {
        // The .Add() method returns true only if the item was not already in the set.
        // This ensures we only count each unique item once.
        if (_collectedItems.Add(itemObject))
        {
            onItemCountChanged?.Invoke(_collectedItems.Count, totalItemsToCollect);

            // Optional: Log a message to the console to confirm tracking.
            Debug.Log($"Item collected: {itemObject.name}. Total: {_collectedItems.Count}/{totalItemsToCollect}");

            // Check if the player has collected all the required items.
            if (_collectedItems.Count >= totalItemsToCollect)
            {
                Debug.Log("All items collected! Calling GameOver.");
                onAllItemsCollected.Invoke();
            }
        }
    }


    // ========== NEW METHOD ========== //
    /// <summary>
    /// Checks if a specific item has been collected.
    /// </summary>
    /// <param name="itemObject">The collectible item to check for.</param>
    /// <returns>True if the item is in the collected set, false otherwise.</returns>
    public bool IsItemCollected(GameObject itemObject)
    {
        // If the itemObject is null, it can't have been collected.
        if (itemObject == null) return false;

        // Return true if the HashSet contains the specified item.
        return _collectedItems.Contains(itemObject);
    }
    // ================================ //

    public void GameOver()
    {
        // Make sure you have a scene at build index 1 in your File > Build Settings.
        SceneManager.LoadScene(1);
    }
}
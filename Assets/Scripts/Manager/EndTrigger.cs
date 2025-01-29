using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class EndTrigger : MonoBehaviour
{
    public GameObject videoDisplay;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            videoDisplay.SetActive(true);

            StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(10f); 
        SceneManager.LoadScene(0);
    }
}

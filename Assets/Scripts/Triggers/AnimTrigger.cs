using UnityEngine;
using UnityEngine.Audio;

public class AnimTrigger : MonoBehaviour
{
    private AudioSource audioSource;
    public Animator animator;

    private string animClip = "still_wheelchair";

    public GameObject requiredItem;

    public bool rollingWheelchair;

    private void Start()
    {
        rollingWheelchair = false;
        audioSource = GetComponent<AudioSource>();
        GameManager.Instance.onAllItemsCollected.AddListener(OnAllItemsCollected);
    }

    private void OnAllItemsCollected()
    {
        Debug.Log("Event received by AnimTrigger! Playing animation.");

        // event itself is the trigger.
        animator.Play(animClip);
        rollingWheelchair = true;
        audioSource.Play();
    }

    private void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.onAllItemsCollected.RemoveListener(OnAllItemsCollected);
        }
    }
}
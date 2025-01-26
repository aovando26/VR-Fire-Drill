using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private AudioSource adultSource;
    private AudioSource teenSource;
    public AudioClip[] dialogueClips; 
    public int currentClipIndex; 

    public void StartDialogue()
    {
        currentClipIndex = 0;
        PlayNextLine();
    }

    private void PlayNextLine()
    {
        if (currentClipIndex > dialogueClips.Length) return;

        // Determine which AudioSource to use based on the index
        AudioSource currentSource = currentClipIndex % 2 == 0 ? adultSource : teenSource;
        currentSource.clip = dialogueClips[currentClipIndex];
        currentSource.Play();

        // Schedule the next line to play after the current one ends
        float clipLength = dialogueClips[currentClipIndex].length;
        currentClipIndex++;
        Invoke(nameof(PlayNextLine), clipLength);
    }
}

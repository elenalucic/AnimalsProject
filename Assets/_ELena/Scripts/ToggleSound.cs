using UnityEngine;

public class ToggleSound : MonoBehaviour
{
    public AudioSource audioSource; 

    private bool isPlaying = false; 

    public void ToggleAudio()
    {
        if (isPlaying)
        {
            audioSource.Stop();  
        }
        else
        {
            audioSource.Play();  
        }

        isPlaying = !isPlaying; 
    }


    private void Update()
    {
        if (!audioSource.isPlaying && isPlaying)
        {
            isPlaying = false;
        }
    }

}

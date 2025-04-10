using System.Collections.Generic;
using UnityEngine;

public class AnimalSoundController : MonoBehaviour
{
    public AnimalDisplay animalDisplay; 

    private AudioSource currentAudio;

    public void PlayCurrentAnimalSound()
    {
        GameObject currentAnimal = animalDisplay.GetCurrentAnimal();

        if (currentAnimal == null)
        {
            Debug.LogWarning("Nema aktivne životinje!");
            return;
        }

     
        currentAudio = currentAnimal.GetComponent<AudioSource>();

        if (currentAudio == null)
        {
            Debug.LogWarning("AudioSource nije pronađen na: " + currentAnimal.name);
            return;
        }

        if (!currentAudio.isPlaying)
        {
            currentAudio.Play();
        }
    }

    public void StopCurrentAnimalSound()
    {
        if (currentAudio != null && currentAudio.isPlaying)
        {
            currentAudio.Stop();
        }
    }
}

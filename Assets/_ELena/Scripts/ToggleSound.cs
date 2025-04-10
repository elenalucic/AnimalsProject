using UnityEngine;

public class AnimalSoundPlayerToggle : MonoBehaviour
{
    public AnimalDisplay animalDisplay;

    public AudioSource kokosAudio;
    public AudioSource mackaAudio;
    public AudioSource pasAudio;
    public AudioSource kravaAudio;

    private AudioSource currentAudio;
    private bool isPlaying = false;

    public void ToggleCurrentAnimalSound()
    {
        GameObject currentAnimal = animalDisplay.GetCurrentAnimal();

        // Zaustavi trenutno sviranje ako postoji
        if (currentAudio != null && currentAudio.isPlaying)
        {
            currentAudio.Stop();
        }

        // Odaberi novi AudioSource ovisno o prikazanoj životinji
        if (currentAnimal.name.Contains("Kokos"))
        {
            currentAudio = kokosAudio;
        }
        else if (currentAnimal.name.Contains("Macka"))
        {
            currentAudio = mackaAudio;
        }
        else if (currentAnimal.name.Contains("Pas"))
        {
            currentAudio = pasAudio;
        }
        else if (currentAnimal.name.Contains("Krava"))
        {
            currentAudio = kravaAudio;
        }
        else
        {
            Debug.LogWarning("Nema zvuka za: " + currentAnimal.name);
            return;
        }

        // Ako je već svirala ista životinja – toggle
        if (isPlaying)
        {
            currentAudio.Stop();
            isPlaying = false;
        }
        else
        {
            currentAudio.Play();
            isPlaying = true;
        }
    }

    private void Update()
    {
        if (currentAudio != null && !currentAudio.isPlaying && isPlaying)
        {
            isPlaying = false;
        }
    }
}

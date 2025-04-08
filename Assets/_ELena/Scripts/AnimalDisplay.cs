using System.Collections.Generic;
using UnityEngine;

public class AnimalDisplay : MonoBehaviour
{
    [Header("Životinje u sceni")]
    public List<GameObject> animalsInScene;

    [Header("Imena životinja (opcionalno za log)")]
    public List<string> animalNames = new List<string> { "Kokos", "Macka", "Krava", "Pas" };

    private GameObject currentAnimal;

    void Start()
    {
        foreach (var animal in animalsInScene)
        {
            animal.SetActive(false);
        }

        SelectAnimal(0);
    }

    public void SelectAnimal(int index)
    {
        if (currentAnimal != null)
            currentAnimal.SetActive(false);

        currentAnimal = animalsInScene[index];
        currentAnimal.SetActive(true);

    }
}


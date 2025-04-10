using System.Collections.Generic;
using UnityEngine;

public class AnimalDisplay : MonoBehaviour
{
    public List<GameObject> animalsInScene;

    public List<string> animalNames = new List<string> { "Kokos", "Macka", "Krava", "Pas" };

    private GameObject currentAnimal;
    private int currentIndex = 0;

    void Start()
    {
        foreach (var animal in animalsInScene)
        {
            animal.SetActive(false);
        }

        SelectAnimal(currentIndex);
    }

    public void SelectAnimal(int index)
    {
        if (currentAnimal != null)
            currentAnimal.SetActive(false);

        currentIndex = index;
        currentAnimal = animalsInScene[currentIndex];
        currentAnimal.SetActive(true);

    }

    public void GoLeft()
    {
        Debug.Log("GO LEFT kliknut!");

        int nextIndex = (currentIndex - 1 + animalsInScene.Count) % animalsInScene.Count;
        SelectAnimal(nextIndex);
    }


    public void GoRight()
    {
        int nextIndex = (currentIndex + 1) % animalsInScene.Count;
        SelectAnimal(nextIndex);
    }
    public GameObject GetCurrentAnimal()
    {
        return currentAnimal; 
    }

}


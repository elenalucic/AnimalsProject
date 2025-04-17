using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Localization;



public class AnimalInfo
{
    public GameObject animalObject;
    public string displayName;
}


public class AnimalDisplay : MonoBehaviour
{
    public List<GameObject> animalsInScene;
    public AnimalSoundController soundController;

    private GameObject currentAnimal;
    private int currentIndex = 0;

    public List<string> animalNames;
    public TextMeshProUGUI animalNameText;


    public List<string> animalNamesLat;
    public TextMeshProUGUI animalNameLatText;

    public List<LocalizedString> localizedAnimalNames;
    public TextMeshProUGUI animalNameLocText;



    private Dictionary<GameObject, Vector3> originalScales = new Dictionary<GameObject, Vector3>();

    void Start()
    {
        foreach (var animal in animalsInScene)
        {
            animal.SetActive(false);
            originalScales[animal] = animal.transform.localScale;
        }

        SelectAnimal(currentIndex);
    }

    public void SelectAnimal(int index)
    {
        if (currentAnimal != null)
        {
            currentAnimal.SetActive(false);
            currentAnimal.transform.localScale = originalScales[currentAnimal];
        }

   

        currentIndex = index;
        currentAnimal = animalsInScene[currentIndex];
        currentAnimal.SetActive(true);
   
        currentAnimal.transform.localScale = originalScales[currentAnimal];

        if (animalNameText != null && animalNames != null && currentIndex < animalNames.Count)
        {
            animalNameText.text = animalNames[currentIndex];
        }

        if (animalNameLatText != null && animalNamesLat != null && currentIndex < animalNamesLat.Count)
        {
            animalNameLatText.text = animalNamesLat[currentIndex];
        }

        if (animalNameText != null && localizedAnimalNames != null && currentIndex < localizedAnimalNames.Count)
        {
            localizedAnimalNames[currentIndex].StringChanged += UpdateAnimalName;
            localizedAnimalNames[currentIndex].RefreshString();
        }

    }

    private void UpdateAnimalName(string localizedText)
    {
        animalNameText.text = localizedText;
    }

    public void GoLeft()
    {
        int nextIndex = (currentIndex - 1 + animalsInScene.Count) % animalsInScene.Count;
        SelectAnimal(nextIndex);
        soundController?.UpdateSoundButtonState();
    }

    public void GoRight()
    {
        int nextIndex = (currentIndex + 1) % animalsInScene.Count;
        SelectAnimal(nextIndex);
        soundController?.UpdateSoundButtonState();
    }

    public GameObject GetCurrentAnimal()
    {
        return currentAnimal;
    }

    public Vector3 GetOriginalScale(GameObject animal)
    {
        if (originalScales.ContainsKey(animal))
            return originalScales[animal];
        else
            return animal.transform.localScale;
    }

}

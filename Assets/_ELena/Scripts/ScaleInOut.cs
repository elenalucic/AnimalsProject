using UnityEngine;
using System.Collections.Generic;

public class ScaleInOut : MonoBehaviour
{
    public GameObject Object;
    public AnimalDisplay animalDisplay;

    public float ScaleStep = 0.2f;
    public float MaxScale = 2f;
    private Vector3 originalScale;

    void Start()
    {
        originalScale = Object.transform.localScale;
    }

    public void Zoom()


    {
        GameObject current = animalDisplay.GetCurrentAnimal();
        if (current == null)
            return;

        float currentScale = current.transform.localScale.x;

        if (currentScale < MaxScale)
        {
            Object.transform.localScale += new Vector3(ScaleStep, ScaleStep, ScaleStep);
        }
        else
        {
            Object.transform.localScale = originalScale;
        }
    }
}




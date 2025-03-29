using UnityEngine;
using System.Collections;
using System.Collections.Generic;


using UnityEngine;

public class ScaleInOut : MonoBehaviour
{
    public GameObject Object; 

    public float ScaleStep = 0.2f; 
    public float MaxScale = 2f;
    private Vector3 originalScale;

    void Start()
    {
        originalScale = Object.transform.localScale; 
    }

    public void Zoom()
    {
        float currentScale = Object.transform.localScale.x;

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


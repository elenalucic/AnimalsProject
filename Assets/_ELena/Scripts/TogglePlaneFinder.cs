using UnityEngine;
using Vuforia;

public class TogglePlaneFinder : MonoBehaviour
{
    public PlaneFinderBehaviour planeFinder;  
    private bool isEnabled = true;  
    public GameObject infoCanvas;
    public GameObject targetObject;


    private Quaternion initialRotation;

    void Start()
    {
        if (targetObject != null)
        {
            initialRotation = targetObject.transform.rotation;
        }
    }

    public void ToggleFinder()
    {
        isEnabled = !isEnabled;
        planeFinder.gameObject.SetActive(isEnabled);
    }

    public void ToggleInfo()
    {
        infoCanvas.SetActive(!infoCanvas.activeSelf);

        if (infoCanvas.activeSelf && targetObject != null)
        {
            targetObject.transform.rotation = initialRotation;
        }
    }

}

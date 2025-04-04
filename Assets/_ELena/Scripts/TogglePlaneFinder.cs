using UnityEngine;
using Vuforia;

public class TogglePlaneFinder : MonoBehaviour
{
    public PlaneFinderBehaviour planeFinder;  
    private bool isEnabled = true;  
    public GameObject infoCanvas;
    public GameObject targetObject;


    private Quaternion initialRotation;

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
            Vector3 directionToCamera = Camera.main.transform.position - targetObject.transform.position;
            directionToCamera.y = 0; 
            targetObject.transform.rotation = Quaternion.LookRotation(directionToCamera);
        }
    }

}

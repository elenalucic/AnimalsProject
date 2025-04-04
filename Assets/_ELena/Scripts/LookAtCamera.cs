using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    
    public void AlignToCamera()
    {
        if (Camera.main)
        {
            Vector3 directionToCamera = Camera.main.transform.position - transform.position;
            directionToCamera.y = 0; 
            transform.rotation = Quaternion.LookRotation(directionToCamera);
        }
    }
}

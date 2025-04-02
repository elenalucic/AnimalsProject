using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class RotateObject : MonoBehaviour
{
    public GameObject objectRotate;

    public float rotateSpeed = 50f;
    bool rotateStatus = false;
    private int rotateDirection = 1;


    public void RotateLeft()
    {

        if (rotateStatus== false)
        {
            rotateStatus = true;
            rotateDirection = -1;
        }
        else
        {
            rotateStatus = false;
        }
    }

    public void RotateRight()
    {

        if (rotateStatus == false)
        {
            rotateStatus = true;
            rotateDirection = 1;
        }
        else
        {
            rotateStatus = false;
        }
    }

    void Update()
    {
        if (rotateStatus == true)
        {
            objectRotate.transform.Rotate(Vector3.up,rotateDirection * rotateSpeed * Time.deltaTime);
        }
    }
}

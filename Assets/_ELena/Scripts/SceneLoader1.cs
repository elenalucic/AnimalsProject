using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader1 : MonoBehaviour
{

    public void LoadAnimalSelector()
    {
        SceneManager.LoadScene("AnimalSelection", LoadSceneMode.Single);
    }


    public void LoadAboutUs()
    {
        SceneManager.LoadScene("AboutUs", LoadSceneMode.Single);
    }



    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void Confirm()
    {
        SceneManager.LoadScene("Domace", LoadSceneMode.Single);
    }
}

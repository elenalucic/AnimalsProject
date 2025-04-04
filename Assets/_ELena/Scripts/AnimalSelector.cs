using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnimalSelector : MonoBehaviour
{

    public GameObject nameOfGroup;
    public Sprite domaceName;
    public Sprite divljeName;
    public Sprite insektiName;
    public Sprite fishName;
    public Sprite birdsName;
    public Sprite seashellName;

    public GameObject picOfGroup;
    public Sprite domacePic;
    public Sprite divljePic;
    public Sprite insektiPic;
    public Sprite fishPic;
    public Sprite birdsPic;
    public Sprite seashellPic;

    private string currentGroup = "domace";


    public void GoRight()
    {
        string nextGroup = "";
        switch (currentGroup)
        {
            case "domace":
                nextGroup = "divlje";
                break;
            case "divlje":
                nextGroup = "insekti";
                break;
            case "insekti":
                nextGroup = "ribe";
                break;
            case "ribe":
                nextGroup = "ptice";
                break;
            case "ptice":
                nextGroup = "skoljke";
                break;
            case "skoljke":
                nextGroup = "domace";
                break;
            default:
                break;
        }
        ChangeGroup(nextGroup);

    }

    public void GoLeft()
    {
        string nextGroup = "";
        switch (currentGroup)
        {
            case "domace":
                nextGroup = "skoljke";
                break;
            case "divlje":
                nextGroup = "domace";
                break;
            case "insekti":
                nextGroup = "divlje";
                break;
            case "ribe":
                nextGroup = "insekti";
                break;
            case "ptice":
                nextGroup = "ribe";
                break;
            case "skoljke":
                nextGroup = "ptice";
                break;
            default:
                break;
        }
        ChangeGroup(nextGroup);
    }

    public void ChangeGroup(string nextGroup)
    {
        switch (nextGroup)
        {
            case "domace":
                nameOfGroup.GetComponent<Image>().sprite = domaceName;
                picOfGroup.GetComponent<Image>().sprite = domacePic;
                break;
            case "divlje":
                nameOfGroup.GetComponent<Image>().sprite = divljeName;
                picOfGroup.GetComponent<Image>().sprite = divljePic;
                break;
            case "insekti":
                nameOfGroup.GetComponent<Image>().sprite = insektiName;
                picOfGroup.GetComponent<Image>().sprite = insektiPic;
                break;
            case "ribe":
                nameOfGroup.GetComponent<Image>().sprite = fishName;
                picOfGroup.GetComponent<Image>().sprite = fishPic;
                break;
            case "ptice":
                nameOfGroup.GetComponent<Image>().sprite = birdsName;
                picOfGroup.GetComponent<Image>().sprite = birdsPic;
                break;
            case "skoljke":
                nameOfGroup.GetComponent<Image>().sprite = seashellName;
                picOfGroup.GetComponent<Image>().sprite = seashellPic;
                break;
            default:
                break;
        }
        currentGroup = nextGroup;
    }

    public void ConfirmSelection()
    {
        switch (currentGroup)
        {
            case "domace":
                SceneManager.LoadScene("Domace");
                break;
            case "divlje":
                SceneManager.LoadScene("Divlje");
                break;
            case "insekti":
                SceneManager.LoadScene("Insekti");
                break;
            case "ribe":
                SceneManager.LoadScene("Ribe");
                break;
            case "ptice":
                SceneManager.LoadScene("Ptice");
                break;
            case "skoljke":
                SceneManager.LoadScene("Skoljke");
                break;
            default:
                Debug.LogError("Nepoznata grupa: " + currentGroup);
                break;
        }
    }



}


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Localization;
using UnityEngine.ResourceManagement.AsyncOperations;



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

    public LocalizedSprite domaceNameLocalized;
    public LocalizedSprite divljeNameLocalized;
    public LocalizedSprite insektiNameLocalized;
    public LocalizedSprite fishNameLocalized;
    public LocalizedSprite birdsNameLocalized;
    public LocalizedSprite seashellNameLocalized;


    private string currentGroup = "domace";

    private void Start()
    {
        LoadLocalizedSprite(domaceNameLocalized);
        picOfGroup.GetComponent<Image>().sprite = domacePic;
    }
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
                LoadLocalizedSprite(domaceNameLocalized);
                picOfGroup.GetComponent<Image>().sprite = domacePic;
                break;
            case "divlje":
                LoadLocalizedSprite(divljeNameLocalized);
                picOfGroup.GetComponent<Image>().sprite = divljePic;
                break;
            case "insekti":
                LoadLocalizedSprite(insektiNameLocalized);
                picOfGroup.GetComponent<Image>().sprite = insektiPic;
                break;
            case "ribe":
                LoadLocalizedSprite(fishNameLocalized);
                picOfGroup.GetComponent<Image>().sprite = fishPic;
                break;
            case "ptice":
                LoadLocalizedSprite(birdsNameLocalized);
                picOfGroup.GetComponent<Image>().sprite = birdsPic;
                break;
            case "skoljke":
                LoadLocalizedSprite(seashellNameLocalized);
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

    private void LoadLocalizedSprite(LocalizedSprite localizedSprite)
    {
        localizedSprite.LoadAssetAsync().Completed += handle =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                nameOfGroup.GetComponent<Image>().sprite = handle.Result;
            }
            else
            {
                Debug.LogError("Greška prilikom učitavanja lokalizirane slike.");
            }
        };
    }



}

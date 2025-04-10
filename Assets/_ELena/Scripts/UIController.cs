using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class UIController : MonoBehaviour
{
    public Button[] buttonsToDisable;
    public GameObject backButton;

    private bool buttonsEnabled = false;

    void Start()
    {
        foreach (Button btn in buttonsToDisable)
        {
            btn.interactable = false;
        }
    }

    public void OnContentPlaced(AnchorBehaviour anchor)
    {
        if (!buttonsEnabled)
        {
            EnableButtons();
            buttonsEnabled = true;
        }
    }


    public void EnableButtons()
    {
        foreach (Button btn in buttonsToDisable)
        {
            btn.interactable = true;
        }
    }
}

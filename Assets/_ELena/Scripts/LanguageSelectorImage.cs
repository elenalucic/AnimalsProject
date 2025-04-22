using UnityEngine;
using UnityEngine.UI;

public class LanguageSelectorImages : MonoBehaviour
{
    public Button hrButton;
    public Button enButton;

    private Image hrImage;
    private Image enImage;

    public Color activeColor = Color.yellow;
    public Color inactiveColor = Color.white;

    private string currentLanguage;

    void Start()
    {
        hrImage = hrButton.GetComponent<Image>();
        enImage = enButton.GetComponent<Image>();

        // Uèitaj zadnji jezik iz PlayerPrefs ili postavi HR kao default
        currentLanguage = PlayerPrefs.GetString("AppLanguage", "HR");
        ApplyLanguageVisuals();

        hrButton.onClick.AddListener(() => ChangeLanguage("HR"));
        enButton.onClick.AddListener(() => ChangeLanguage("EN"));
    }

    void ChangeLanguage(string lang)
    {
        currentLanguage = lang;
        PlayerPrefs.SetString("AppLanguage", lang);
        PlayerPrefs.Save();

        ApplyLanguageVisuals();

        // Ovdje možeš pozvati dodatne metode za promjenu jezika u app
    }

    void ApplyLanguageVisuals()
    {
        bool isHR = currentLanguage == "HR";

        if (hrImage != null)
            hrImage.color = isHR ? activeColor : inactiveColor;

        if (enImage != null)
            enImage.color = !isHR ? activeColor : inactiveColor;
    }
}

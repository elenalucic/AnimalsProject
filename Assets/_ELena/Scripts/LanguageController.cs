using UnityEngine;
using UnityEngine.Localization.Settings;


public class LanguageController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectLanguage(int localeIndex)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeIndex];
    }
}

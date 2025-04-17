using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class ChangeLanguage : MonoBehaviour
{
    public Locale HRLocale;
    public Locale ENLocale;

    private void Start()
    {
        InitLanguage();
    }

    private void InitLanguage()
    {
        if (PlayerPrefs.HasKey("Language"))
        {
            // Učitaj spremljeni jezik
            string lang = PlayerPrefs.GetString("Language");
            ApplyLanguage(lang);
        }
        else
        {
            // Ako nije postavljeno, koristi HR kao default
            SetLanguage("hr");
        }
    }

    /// <summary>
    /// Postavlja jezik i sprema u PlayerPrefs
    /// </summary>
    /// <param name="lang">"hr" ili "en"</param>
    public void SetLanguage(string lang)
    {
        ApplyLanguage(lang);
        PlayerPrefs.SetString("Language", lang);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Vraća trenutno spremljeni jezik iz PlayerPrefsa
    /// </summary>
    /// <returns>"hr" ili "en"</returns>
    public string GetLanguage()
    {
        return PlayerPrefs.GetString("Language", "hr"); // default ako nešto krene po zlu
    }

    /// <summary>
    /// Primjenjuje jezik bez spremanja u prefs
    /// </summary>
    /// <param name="lang"></param>
    private void ApplyLanguage(string lang)
    {
        switch (lang)
        {
            case "hr":
                LocalizationSettings.SelectedLocale = HRLocale;
                break;
            case "en":
                LocalizationSettings.SelectedLocale = ENLocale;
                break;
            default:
                LocalizationSettings.SelectedLocale = HRLocale; // fallback
                break;
        }
    }
}
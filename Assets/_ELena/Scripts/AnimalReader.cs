using TMPro;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class AnimalReader : MonoBehaviour
{
    public Button readButton;  
    private bool isReading = false;
    private string currentInfoText = "";

    void Start()
        {
            if (readButton != null)
            {
                readButton.interactable = false;
                Debug.Log("[TTS] Gumb je na po�etku deaktiviran.");
            }
     }

    void Update()
        {
           
            bool infoActive = IsInfoTextActive();

            if (readButton != null)
            {
                readButton.interactable = infoActive;
            }

   
    }


    public void ReadAnimalInfo()
    {
        string info = "";

        Canvas[] canvases = FindObjectsByType<Canvas>(FindObjectsSortMode.None);
        foreach (var canvas in canvases)
        {
            if (canvas.gameObject.activeInHierarchy)
            {
                Debug.Log("[TTS] Provjeravam canvas: " + canvas.name);

                TextMeshProUGUI[] textComponents = canvas.GetComponentsInChildren<TextMeshProUGUI>(true);
                foreach (var textComp in textComponents)
                {
                    Debug.Log("[TTS] Prona�en text: " + textComp.name);
                    if (textComp.name.ToLower().Contains("text") && !string.IsNullOrEmpty(textComp.text))
                    {
                        info = textComp.text;
                        Debug.Log("[TTS] Prona�en info tekst: " + info);
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(info)) break;
            }
        }

        if (!string.IsNullOrEmpty(info))
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                AndroidJavaObject tts = new AndroidJavaObject("ir.hoseinporazar.androidtts.TTS");
                tts.Call("setContext", activity);
                tts.Call("TTSMEWithCallBack", info, gameObject.name, "OnTTSError");
            }
#else
            Debug.Log("[TTS] (Editor) Govori: " + info);
#endif
        }
        else
        {
            Debug.LogWarning("[TTS] Tekst je prazan ili null � ne�e se pokrenuti TTS.");
        }
    }

    public void OnTTSError(string message)
    {
        Debug.LogError("TTS Error: " + message);
    }



    private bool IsInfoTextActive()
    {
        Canvas[] canvases = FindObjectsByType<Canvas>(FindObjectsSortMode.None);
        foreach (var canvas in canvases)
        {
            if (canvas.gameObject.activeInHierarchy)
            {
                TextMeshProUGUI[] textComponents = canvas.GetComponentsInChildren<TextMeshProUGUI>(true);
                foreach (var textComp in textComponents)
                {
                    if (textComp.name.ToLower().Contains("text") && !string.IsNullOrEmpty(textComp.text))
                    {
                        return textComp.gameObject.activeInHierarchy;
                    }
                }
            }
        }
        return false;
    }
}

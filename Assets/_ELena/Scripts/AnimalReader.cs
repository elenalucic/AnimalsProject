using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NativeTextToSpeech;
using UnityEngine.SceneManagement;

public class AnimalReader : MonoBehaviour
{
    private TextToSpeech _tts;
    private bool isReading = false;
    private string currentInfoText = "";
    private Canvas currentActiveCanvas = null;

    [SerializeField] private Button readButton;
    [SerializeField] private string language = "en-US";
    [SerializeField] private float rate = 0.8f;

    void Start()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        _tts = TextToSpeech.Create(OnFinish, OnError);
#endif

        if (readButton != null)
        {
            readButton.onClick.AddListener(OnReadButtonClicked);
            readButton.interactable = false;
            Debug.Log("[TTS] Gumb za čitanje inicijalno deaktiviran.");
        }

        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    void Update()
    {
        Canvas newActiveCanvas = GetActiveCanvasWithText();

        // Ako se aktivni canvas promijenio (druga životinja), zaustavi čitanje
        if (newActiveCanvas != currentActiveCanvas)
        {
            currentActiveCanvas = newActiveCanvas;
            StopReading();
        }

        if (readButton != null)
        {
            // Gumb aktivan samo ako postoji aktivan canvas s tekstom
            readButton.interactable = currentActiveCanvas != null;
        }
    }

    private Canvas GetActiveCanvasWithText()
    {
        Canvas[] canvases = FindObjectsByType<Canvas>(FindObjectsSortMode.None);

        foreach (var canvas in canvases)
        {
            if (!canvas.gameObject.activeInHierarchy) continue;

            TextMeshProUGUI[] texts = canvas.GetComponentsInChildren<TextMeshProUGUI>(true);

            foreach (var text in texts)
            {
                if (text.name.ToLower().Contains("text") && !string.IsNullOrEmpty(text.text))
                {
                    currentInfoText = text.text;
                    return canvas;
                }
            }
        }

        currentInfoText = "";
        return null;
    }

    private void OnReadButtonClicked()
    {
        if (isReading)
        {
            StopReading();
        }
        else
        {
            StartReading();
        }
    }

    private void StartReading()
    {
        if (string.IsNullOrEmpty(currentInfoText)) return;

#if UNITY_ANDROID && !UNITY_EDITOR
        if (_tts != null)
        {
            _tts.Speak(currentInfoText, language, rate);
        }
#endif
        isReading = true;
        Debug.Log("[TTS] Početak čitanja: " + currentInfoText);
    }

    private void StopReading()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        if (_tts != null)
        {
            _tts.Stop();
        }
#endif
        isReading = false;
        Debug.Log("[TTS] Čitanje zaustavljeno.");
    }

    private void OnFinish()
    {
        isReading = false;
        Debug.Log("[TTS] Završeno čitanje.");
    }

    private void OnError(string message)
    {
        isReading = false;
        Debug.LogWarning("[TTS] Greška: " + message);
    }

    private void OnSceneUnloaded(Scene scene)
    {
        StopReading();
    }

    private void OnDestroy()
    {
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }
}

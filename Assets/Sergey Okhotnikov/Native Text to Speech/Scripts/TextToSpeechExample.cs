using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using NativeTextToSpeech;

public class TextToSpeechExample : MonoBehaviour
{
    [SerializeField] private InputField TextInput;
    [SerializeField] private InputField LanguageInput;
    [SerializeField] private InputField RateInput;
    [SerializeField] private Button SpeakButton;
    [SerializeField] private Button StopButton;
    [SerializeField] private bool threadSafe;

    private bool _isFinished;
    private bool _finishReceived;
    private Queue<string> errors = new Queue<string>();

    private TextToSpeech _textToSpeech;

    public void Speak()
    {
            #if UNITY_ANDROID
                    using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
                    {
                        AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                        AndroidJavaObject ttsObject = new AndroidJavaObject("android.speech.tts.TextToSpeech"); // tvoje ime klase
                        ttsObject.Call("setContext", activity);
                       
                    }
            #endif
    }

    public void Stop()
    {
        // Add logic to stop TTS if the stop functionality is available.
#if UNITY_ANDROID
        using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject tts = new AndroidJavaObject("android.speech.tts.TextToSpeech", activity, null);
            tts.Call("stop"); // Call the stop method to stop speech synthesis on Android
        }
#endif
    }

    private void OnFinish()
    {
        if (threadSafe)
        {
            _finishReceived = true;
        }
        else
        {
            TTSFinished();
        }
    }

    private void OnError(string msg)
    {
        if (threadSafe)
        {
            errors.Enqueue(msg);
        }
        else
        {
            ShowError(msg);
        }
    }

    private void ShowError(string error)
    {
        Debug.LogWarning("Error received in Unity main thread: " + error);
    }

    private void TTSFinished()
    {
        SpeakButton.interactable = true;
        StopButton.interactable = false;
    }

    private void TTSStarted()
    {
        SpeakButton.interactable = false;
        StopButton.interactable = true;
    }

    void Start()
    {
        // Initialize TextToSpeech
#if UNITY_ANDROID
        using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject tts = new AndroidJavaObject("android.speech.tts.TextToSpeech", activity, null);
            tts.Call("create"); // Call the stop method to stop speech synthesis on Android
        }
#endif
        LanguageInput.text = "en-US";
        RateInput.text = "0.8";
    }

    void Update()
    {
        if (!threadSafe)
        {
            return;
        }

        if (_finishReceived)
        {
            _finishReceived = false;
            TTSFinished();
        }

        while (errors.Count > 0)
        {
            ShowError(errors.Dequeue());
        }
    }
}

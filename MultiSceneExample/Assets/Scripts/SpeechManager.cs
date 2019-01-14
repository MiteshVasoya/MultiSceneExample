using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Windows.Speech;

public class SpeechManager : MonoBehaviour
{
    //Recognize specific speech keywords
    KeywordRecognizer keywordRecognizer = null;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    //To display recognized speech command
    public GameObject recognizedText;

    //Delegate to callback the recognized speech on other scenes
    public delegate void SpeechRecognizedCallBack(string text);
    public event SpeechRecognizedCallBack OnSpeechRecognized;

    //Initialize speech callback to get recognized text on other(child) scenes
    public void startSpeechCallback(SpeechRecognizedCallBack speechRecognizedCallBack)
    {
        OnSpeechRecognized = speechRecognizedCallBack;
    }

    // Use this for initialization
    void Start()
    {
        keywords.Add("Show menu", () =>
        {
            displaySpeechText("Show Menu");
        });

        keywords.Add("Start animation", () =>
        {
            displaySpeechText("Start Animation");
        });

        keywords.Add("Up", () =>
        {
            displaySpeechText("Up");
        });

        keywords.Add("Down", () =>
        {
            displaySpeechText("Down");
        });

        keywords.Add("Left", () =>
        {
            displaySpeechText("Left");
        });

        keywords.Add("Right", () =>
        {
            displaySpeechText("Right");
        });

        keywords.Add("Hologram", () =>
        {
            displaySpeechText("Hologram");
        });

        // Tell the KeywordRecognizer about our keywords.
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        // Register a callback for the KeywordRecognizer and start recognizing!
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }
    
    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
            //Send recognized speech to the callbacks
            OnSpeechRecognized(args.text);
        }
    }

    private void displaySpeechText(string message)
    {
        recognizedText.GetComponent<TextMesh>().text = message;
        Debug.Log(message);
    }
}

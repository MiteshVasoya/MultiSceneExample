using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSpeechRecognizer : MonoBehaviour {

    SpeechManager speechManager;

    // Use this for initialization
    void Start () {
        //Get speech manager from master(main) scene
        speechManager = GameObject.Find("SpeechManager").GetComponent<SpeechManager>();
        //Initialized the speech callback with method defined in this class
        speechManager.startSpeechCallback(OnSpeechRecognized);
	}

    private void OnSpeechRecognized(string text)
    {
        //Display recognized speech text as it arrives
        if(text!=null)
            Debug.Log("Scene: " + SceneManager.GetActiveScene().name + ", Speech: "+text);
    }
}

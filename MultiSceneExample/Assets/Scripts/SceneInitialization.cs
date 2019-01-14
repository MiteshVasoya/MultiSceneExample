using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInitialization : MonoBehaviour {

    //First scene to load with master scene
    public string initialScene;

	// Use this for initialization
	void Start () {
        //load first scene if present
        if (initialScene != null)
        {
            Debug.Log("Loading " + initialScene + " with Master Scene...");
            SceneManager.LoadSceneAsync(initialScene, LoadSceneMode.Additive);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

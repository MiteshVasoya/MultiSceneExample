using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour, IInputClickHandler {

    public string switchingSceneName;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        //Load new scene on object tapped
        Debug.Log("Changing scene to "+ switchingSceneName);
        LoadSceneAdditively(switchingSceneName);
    }
    
    private static void LoadSceneAdditively(string sceneName)
    {
        //unload all scenes except master scene
        unloadAllScenes();
        //load a new scene
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }
    
    private static void unloadAllScenes()
    {
        //if there are multiple scenes presents
        if (SceneManager.sceneCount > 1)
        {
            //scene at index 0 will be master scene
            //remove scenes from index 1
            for (int i = 1; i < SceneManager.sceneCount; i++)
            {
                //unload the scene
                Debug.Log("Removing " + SceneManager.GetSceneAt(i).name);
                SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(i));
            }
        }
    }
}

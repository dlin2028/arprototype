using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrosshairSceneLoader : MonoBehaviour
{
    public float UserHeight = 0;
    public void LoadCHSceneAdditiveAsync(string sceneName)
    {
        StartCoroutine(loadCHSceneAsync(sceneName, UserHeight));
    }
    
    private IEnumerator loadCHSceneAsync(string sceneName, float userHeight)
    {
        if (SceneManager.GetSceneByName(sceneName).IsValid())
        {
            AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(sceneName);
            while (!asyncUnload.isDone)
            {
                yield return null;
            }
        }

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        CrosshairSceneOrigin sceneOrigin = FindObjectOfType<CrosshairSceneOrigin>();
        if (!sceneOrigin)
        {
            Debug.LogError("There is no object with a CrosshairSceneOrigin script in " + sceneName);
        }

        sceneOrigin.RotateScene(userHeight);
    }
}

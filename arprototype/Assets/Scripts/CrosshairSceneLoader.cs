using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrosshairSceneLoader : MonoBehaviour
{
    public void LoadCHSceneAdditiveAsync(string sceneName)
    {
        StartCoroutine(loadCHSceneAsync(sceneName));
    }

    private IEnumerator loadCHSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        while(!asyncLoad.isDone)
        {
            yield return null;
        }
        CrosshairSceneOrigin sceneOrigin = FindObjectOfType<CrosshairSceneOrigin>();
        sceneOrigin.RotateScene();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrosshairSceneOrigin : MonoBehaviour
{
    public GameObject Crosshair;

    public void RotateScene()
    {
        transform.LookAt(Crosshair.transform.position);
        foreach (var go in gameObject.scene.GetRootGameObjects())
        {
            go.transform.parent = transform;
        }

        transform.rotation = Camera.main.transform.rotation;
    }
}

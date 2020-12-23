using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrosshairSceneOrigin : MonoBehaviour
{
    public GameObject Crosshair;

    public void RotateScene(float userHeight)
    {
        if(transform.position.y != 0)
        {
            Debug.Log("Y position is not set to 0. This will be overwritten");
        }
        if(!Crosshair)
        {
            Debug.LogError("Crosshair was null, please set it to a valid gameobject");
        }
        
        transform.position = new Vector3(transform.position.x, userHeight, transform.position.z);
        transform.LookAt(Crosshair.transform.position);
        foreach (var go in gameObject.scene.GetRootGameObjects())
        {
            if(go != gameObject)
                go.transform.parent = transform;
        }

        transform.position = Camera.main.transform.position;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, Camera.main.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
}

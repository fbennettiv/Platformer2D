using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTimer : MonoBehaviour
{
    public enum SceneType
    { 
        Number,
        String
    }

    public float timeToWait = 3f;

    public SceneType sceneType;
    public int nextSceneInt;
    public string nextSceneString;

    void Start()
    {
        Invoke("NextScene", timeToWait); //Invoke is a built in method that says after the number of waiting, invoke this specific thing
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            NextScene();
        }
    }

    private void NextScene()
    {
        if (sceneType == SceneType.Number)
        {
            SceneManager.LoadScene(nextSceneInt);
        }
        else
        {
            SceneManager.LoadScene(nextSceneString);
        }
    }
}

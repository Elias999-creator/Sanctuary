using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public int sceneToLoad;

    public void Update()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}

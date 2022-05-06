using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Warning : MonoBehaviour
{
    public int sceneToLoad;

    public void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }

    public void Update()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(5);
    }
}

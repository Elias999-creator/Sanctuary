using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpTrigger : MonoBehaviour
{
    public AudioSource Scream;
    public GameObject JumpCam;
    public GameObject flashImg;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Scream.Play();
            JumpCam.SetActive(true);
            flashImg.SetActive(true);
            StartCoroutine(EndJump());
        }
    }

    IEnumerator EndJump()
    {
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene(0);
    }
}

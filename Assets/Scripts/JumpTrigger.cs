using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    public AudioSource Scream;
    public GameObject JumpCam;
    public GameObject flashImg;

    void OnTriggerEnter()
    {
        Scream.Play();
        JumpCam.SetActive(true);
        flashImg.SetActive(true);
        StartCoroutine(EndJump());
    }

    IEnumerator EndJump()
    {
        yield return new WaitForSeconds(2.03f);
        JumpCam.SetActive(true);
        flashImg.SetActive(false);
    }
}

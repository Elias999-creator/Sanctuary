using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    public GameObject _noteImage;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _noteImage.active = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _noteImage.active = false;
        }
    }
}

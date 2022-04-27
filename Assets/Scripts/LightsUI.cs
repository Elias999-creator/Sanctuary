using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightsUI : MonoBehaviour
{
    public GameObject Light;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Light.active = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Light.active = false;
        }
    }
}

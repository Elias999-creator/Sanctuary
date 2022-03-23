using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    static public Main Instance;

    public GameObject down;
    public GameObject off;
    public bool isOff;
    public bool isDown;

    // Start is called before the first frame update
    void Start()
    {
        down.SetActive(isOff);
        off.SetActive(isDown);
        if (isOff)
        {
            Main.Instance.SwitchChange(1);
        }
    }

    public void Switchlight()
    {

        Debug.Log("Click");

        isDown = !isDown;
        isOff = !isOff;
        off.SetActive(isOff);
        down.SetActive(isDown);

        if (isOff)
        {
            Main.Instance.SwitchChange(1);
        }
        else
        {
            Main.Instance.SwitchChange(-1);
        }
    }
}
   

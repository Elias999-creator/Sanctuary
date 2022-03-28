using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checklist : MonoBehaviour
{
    public GameObject checklistUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            checklistUI.SetActive(!checklistUI.activeSelf);
        }
    }
}

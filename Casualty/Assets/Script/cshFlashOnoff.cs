using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshFlashOnoff : MonoBehaviour
{
    public GameObject flashlight;
    private bool isTurnOn = false;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight.SetActive(isTurnOn);
            isTurnOn = !isTurnOn;
        }
    }
}

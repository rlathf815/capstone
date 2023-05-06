using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshAutoDoorDetective : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "AutoDoorDetectArea")
        {
            col.gameObject.GetComponent<cshOpenDoor>().OnOff = true;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "AutoDoorDetectArea")
        {
            col.gameObject.GetComponent<cshOpenDoor>().OnOff = false;
        }
    }
}

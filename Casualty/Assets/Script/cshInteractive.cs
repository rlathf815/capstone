using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshInteractive : MonoBehaviour
{
    void OnTriggerStay(Collider col)
    {
        if(col.tag == "interactive")
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                col.gameObject.GetComponent<cshInteractived>().Interactived();
            }
        }
    }
    
}

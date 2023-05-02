using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshInteractived : MonoBehaviour
{
    
    public void Interactived()
    {
        OpenElevator.OnOff = !OpenElevator.OnOff;
        print(OpenElevator.OnOff);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initialize : MonoBehaviour
{
    public SharedData sharedData;
    // Start is called before the first frame update
    void Start()
    {
        sharedData.initial = true;
        sharedData.patient1 = false;
        sharedData.patient2 = false;
        sharedData.patient3 = false;
        sharedData.dillemaPatient = 0;
        sharedData.dillemaRunOver = false;
        sharedData.bodyParked = false;
        sharedData.HorrorInitial = true;
        sharedData.hasEntered = false;
        sharedData.horrorPatient = false;
        sharedData.horrorPatient2 = false;
        sharedData.bodyParked2 = false;
        sharedData.isCaught = false;
        sharedData.index = 0;
        sharedData.glitchOn = false;

    }             

    // Update is called once per frame
    void Update()
    {
        
    }
}

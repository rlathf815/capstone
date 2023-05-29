using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCart : MonoBehaviour
{

    public GameObject cart;
    public GameObject newCart;
    public SharedData sharedData;

    private void Start()
    {
        if (sharedData.HorrorInitial)
        {
            if (sharedData.dillemaPatient != 0)
            {
                Debug.Log("patient killed");
                cart.SetActive(true);
            }

            else
            {
                Debug.Log("patient not yet killed");

                cart.SetActive(false);
            }
            Debug.Log("not horrorScene yet");

        }
        else
        {
            Debug.Log("horrorScene");

            if ( sharedData.horrorPatient2)
            {
                Debug.Log("patient2notKilled");

                cart.SetActive(true);

            }
        }

    }


}
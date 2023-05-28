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

    }


}
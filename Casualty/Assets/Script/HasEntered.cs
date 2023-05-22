using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasEntered : MonoBehaviour
{
    public SharedData sharedData;
    // Start is called before the first frame update
    void Start()
    {
          sharedData.hasEntered = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
          sharedData.hasEntered = true;

        }
    }
}

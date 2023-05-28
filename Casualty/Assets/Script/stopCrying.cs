using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopCrying : MonoBehaviour
{
    public SharedData shareData;
    public string objectName;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        objectName = gameObject.name;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(objectName == "patient1")
        {
            if (shareData.patient1)
            {
                audioSource.loop = false;
                audioSource.Stop();
            }
            
        }
        else if (objectName == "patient2")
        {
            if (shareData.patient2)
            {
                audioSource.loop = false;
                audioSource.Stop();
            }
        }
        else if (objectName == "patient3")
        {
            if (shareData.patient3)
            {
                audioSource.loop = false;
                audioSource.Stop();
            }
        }


    }
}

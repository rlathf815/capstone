using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshAutoDoorDetective : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "AutoDoorDetectArea")
        {
            col.gameObject.GetComponent<cshOpenDoor>().OnOff = true;
            audioSource = col.gameObject.GetComponent<AudioSource>();
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "AutoDoorDetectArea")
        {
            col.gameObject.GetComponent<cshOpenDoor>().OnOff = false;
            audioSource = col.gameObject.GetComponent<AudioSource>();
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}

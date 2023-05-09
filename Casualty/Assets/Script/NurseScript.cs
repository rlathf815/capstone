using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NurseScript : MonoBehaviour
{
    public GameObject UI;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UI.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UI.SetActive(false);
        }
    }
}
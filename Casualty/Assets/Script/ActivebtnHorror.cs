using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ActivebtnHorror : MonoBehaviour
{
    //public string nextSceneName;
    public GameObject UI;
    public SharedData sharedData;

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player")&&sharedData.horrorPatient == true)
        {
            
            UI.SetActive(true);

           
        }

    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("trigger exited" + other.tag);
        if (other.gameObject.CompareTag("Player"))
        {
            UI.SetActive(false);
        }
    }
}
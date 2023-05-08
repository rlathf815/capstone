using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ActiveBtn : MonoBehaviour
{
    //public string nextSceneName;
    public GameObject UI;
    public PatientData selectedPatient;
    public List<PatientData> allPatientData;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger entered" + other.tag);
        Debug.Log("current patient name = "  + gameObject.name);


        if (other.gameObject.CompareTag("Player"))
        {
            UI.SetActive(true);
            //if (Input.GetKey(KeyCode.E))
            //{
            //    // Load the new scene
            //    SceneManager.LoadScene("MiniGameScene");
            //}
            foreach (PatientData patient in allPatientData)
            {
                if (patient.patientName == gameObject.name)
                {
                    Debug.Log(patient.patientName + " found");
                    selectedPatient.patientName = patient.patientName;
                    selectedPatient.description.AddRange(patient.description);
                }
            }
        }

    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("trigger exited" + other.tag);
        if (other.gameObject.CompareTag("Player"))
        {
            UI.SetActive(false);
            selectedPatient.description.Clear();
        }
    }
}
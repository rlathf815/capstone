using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public Canvas ui;
    public PatientData selectedPatient;
    [SerializeField] public GameObject[] patients;
    private GameObject patient;

    void Start()
    {
        for (int i = 0; i < patients.Length; i++)
        {
            patients[i].SetActive(false);
            if (patients[i].name == selectedPatient.patientName)
                patient = patients[i];
        }
        Debug.Log("patient name = " + selectedPatient.patientName);
        Debug.Log("patient found = " + patient);

        patient.SetActive(true);
    }
    void Update()
    {
        if (ui != null && ui.gameObject.activeSelf)
        {
            StartCoroutine(LoadMapSceneWithDelay());
        }

    }
    IEnumerator LoadMapSceneWithDelay() //Coroutine 사용하여 씬 전환 전 잠시 딜레이
    {
        yield return new WaitForSeconds(2.0f); 

        SceneManager.LoadScene("MapScene"); 
    }
}

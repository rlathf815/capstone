using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public Canvas ui;
    public GameObject surgeryUI;
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

        if(patient.name == "patient2")
        {
            surgeryUI.SetActive(true);
            StartCoroutine(LoadStitchSceneWithDelay());

        }

        if (ui != null && ui.gameObject.activeSelf)
        {
            StartCoroutine(LoadMapSceneWithDelay());
        }

    }
    IEnumerator LoadMapSceneWithDelay() //Coroutine ����Ͽ� �� ��ȯ �� ��� ������
    {
        yield return new WaitForSeconds(2.0f); 

        SceneManager.LoadScene("MapScene"); 
    }
    IEnumerator LoadStitchSceneWithDelay() //Coroutine ����Ͽ� �� ��ȯ �� ��� ������
    {
        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene("StitchMiniGameScene");
    }
}

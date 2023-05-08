using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class getDescription : MonoBehaviour
{
    public TMP_Text clipboard;
    public PatientData selectedPatient;
    private string descriptionString;

    //foreach (string description in selectedPatient.description)
    // {
    //     Debug.Log(description);
    //     descriptionString
    // }
    void Start()
    {
        descriptionString = string.Join("\n", selectedPatient.description.ToArray());
        Debug.Log(descriptionString);
        clipboard.text = descriptionString;
    }

}

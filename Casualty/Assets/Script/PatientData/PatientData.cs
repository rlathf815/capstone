using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Patient Data", menuName = "Patient Data", order = 1)]
public class PatientData : ScriptableObject
{
    public string patientName;
    public List<string> description;
    
}
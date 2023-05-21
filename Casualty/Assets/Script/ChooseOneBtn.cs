using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseOneBtn : MonoBehaviour
{
    public SharedData sharedData;
    public void OnClickExit()
    {
        Application.Quit();
        Debug.Log("button clicked");
    }
    public void OnClickAlex()
    {
        sharedData.dillemaPatient = 1;
        SceneManager.LoadScene("StitchMiniGameScene");
    }
    public void OnClickSarah()
    {
        sharedData.dillemaPatient = 2;
        SceneManager.LoadScene("StitchMiniGameScene");
    }
}

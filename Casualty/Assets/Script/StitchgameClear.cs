using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StitchgameClear : MonoBehaviour
{
    public GameObject ui;
    public GameObject gut;
    public SharedData sharedData;


    void start()
    {

    }
    
    void Update()
    {
        if(gut == null)
        {
            ui.SetActive(true);
            if(sharedData.dillemaPatient == 0 && !sharedData.horrorPatient )
                StartCoroutine(LoadMapSceneWithDelay());
            else if(sharedData.dillemaPatient != 0 &&!sharedData.horrorPatient)
                StartCoroutine(LoadChooseSceneWithDelay());
            else if (sharedData.dillemaPatient != 0 && sharedData.horrorPatient)
                StartCoroutine(LoadHorrorSceneWithDelay());

        }

    }
    IEnumerator LoadMapSceneWithDelay() //Coroutine 사용하여 씬 전환 전 잠시 딜레이
    {
        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene("MapScene");
    }
    IEnumerator LoadChooseSceneWithDelay() //Coroutine 사용하여 씬 전환 전 잠시 딜레이
    {
        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene("ChooseOne");
    }
    IEnumerator LoadHorrorSceneWithDelay() //Coroutine 사용하여 씬 전환 전 잠시 딜레이
    {
        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene("HorrorScene");
    }
}

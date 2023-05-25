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
    IEnumerator LoadMapSceneWithDelay() //Coroutine ����Ͽ� �� ��ȯ �� ��� ������
    {
        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene("MapScene");
    }
    IEnumerator LoadChooseSceneWithDelay() //Coroutine ����Ͽ� �� ��ȯ �� ��� ������
    {
        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene("ChooseOne");
    }
    IEnumerator LoadHorrorSceneWithDelay() //Coroutine ����Ͽ� �� ��ȯ �� ��� ������
    {
        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene("HorrorScene");
    }
}

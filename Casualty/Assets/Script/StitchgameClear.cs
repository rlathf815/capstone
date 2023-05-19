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
        if (gut == null)
        {
            ui.SetActive(true);
            //  }
            //  if (ui != null && ui.gameObject.activeSelf)
            //  {
            StartCoroutine(LoadMapSceneWithDelay());
        }

    }
    IEnumerator LoadMapSceneWithDelay() //Coroutine ����Ͽ� �� ��ȯ �� ��� ������
    {
        yield return new WaitForSeconds(2.0f);
        if (sharedData.dillemaPatient == 0)
            SceneManager.LoadScene("MapScene");
        else
            SceneManager.LoadScene("ChooseOne");
    }
}

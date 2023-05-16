using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StitchgameClear : MonoBehaviour
{
    public GameObject ui;
    public GameObject gut;

    void start()
    {

    }
    
    void Update()
    {
        if(gut == null)
        {
            ui.SetActive(true);
     //  }
     //  if (ui != null && ui.gameObject.activeSelf)
     //  {
            StartCoroutine(LoadMapSceneWithDelay());
        }

    }
    IEnumerator LoadMapSceneWithDelay() //Coroutine 사용하여 씬 전환 전 잠시 딜레이
    {
        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene("MapScene");
    }
}

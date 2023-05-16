using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class openingMenu : MonoBehaviour
{
    public GameObject ui;
    void Start()
    {
        ui.SetActive(false);
    }
    public void OnClickExit()
    {
        Application.Quit();
        Debug.Log("button clicked");
    }
    public void OnClickStart()
    {
        StartCoroutine(LoadScene());
        
    }
    IEnumerator LoadScene()
    {
        ui.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("MapScene");
    }
}

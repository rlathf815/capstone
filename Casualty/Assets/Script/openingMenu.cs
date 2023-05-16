using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class openingMenu : MonoBehaviour
{
    public void OnClickExit()
    {
        Application.Quit();
        Debug.Log("button clicked");
    }
    public void OnClickStart()
    {
        SceneManager.LoadScene("MapScene");
    }
}

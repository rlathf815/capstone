using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public Canvas ui;

    void Update()
    {
        if (ui != null && ui.gameObject.activeSelf)
        {
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene("MiniGameScene");
            }
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HororSceneManage : MonoBehaviour
{
    public SharedData sharedData;
    public GameObject Player;
    public GameObject patient;
    public Transform desiredPosition;
    public GameObject ui1st;
    public GameObject ui2nd;
    // Start is called before the first frame update
    void Start()
    {
        if(!sharedData.HorrorInitial)
        {
            //StartCoroutine(UIFade());
            Player.transform.position = desiredPosition.position;
            Player.transform.rotation = desiredPosition.rotation;
            
        }
        else 
           // sharedData.HorrorInitial = false;
      
        if(sharedData.horrorPatient==true)
        {
            patient.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (ui1st != null && ui1st.activeSelf)
        {
            Debug.Log("UI show");
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene("H_MiniGameScene");

            }
       
        }
        else if (ui2nd != null && ui2nd.activeSelf)
        {
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene("H_StitchMiniGameScene");

            }

        }
    }
   
}

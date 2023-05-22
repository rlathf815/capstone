using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HororSceneManage : MonoBehaviour
{
    public SharedData sharedData;

    // Start is called before the first frame update
    void Start()
    {
        if(sharedData.HorrorInitial)
        {
            //StartCoroutine(UIFade());
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
}

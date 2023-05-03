using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    public int speed = 1;
    public int time = 0;
    public int threshhold = 60;
    public GameObject _light;
    
    void FixedUpdate()
    {
        if (time >= threshhold && time < 100)
        {
            _light.gameObject.SetActive(true);
        }
        else if (time < threshhold)
        {
            _light.gameObject.SetActive(false);
        }
        else
            time = 0;
        time += speed;
    }
}

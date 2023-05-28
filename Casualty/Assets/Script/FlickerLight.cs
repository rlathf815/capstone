using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    public float speed = 10.0f;
    private float time = 0.0f;
    public int threshhold = 60;
    public Renderer myRenderer;
    public GameObject _light;
    private void Start()
    {
        myRenderer = GetComponent<Renderer>();
        myRenderer.enabled = false;
    }
    void Update()
    {
        if (time >= threshhold && time < 100)
        {
            myRenderer.enabled=true;
            _light.gameObject.SetActive(true);
        }
        else if (time < threshhold)
        {
            myRenderer.enabled = false;
            _light.gameObject.SetActive(false);
        }
        else
            time = 0;
        time += Time.deltaTime * speed;
    }
}

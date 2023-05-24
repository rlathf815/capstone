using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JYshakeCam : MonoBehaviour
{
    private float shakeTime;
    private float shakeIntensity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeSelf)
        {
            shakeCamera(2.0f, 0.05f);
            //intensity 0.05가 제일 봐줄만함.
        }        
    }

    void shakeCamera(float shakeTime, float shakeIntensity)
    {
        this.shakeTime = shakeTime;
        this.shakeIntensity = shakeIntensity;

        StopCoroutine("ShakeCamPos");
        StartCoroutine("ShakeCamPos");
    }

    private IEnumerator ShakeCamPos()
    {
        Vector3 currentPos = transform.position;//초기값
        while(shakeTime > 0.0f)
        {
            
            float x = Random.Range(-0.15f, 0.15f);
            float y = Random.Range(-0.15f, 0.15f);
            float z = Random.Range(-0.15f, 0.15f);//수동용
            transform.position = currentPos + new Vector3(0, y, z) * shakeIntensity;
            


            //transform.position = currentPos + Random.insideUnitSphere * shakeIntensity;
            //발작이 심함.
            shakeTime -= Time.deltaTime;

            yield return null;
            //딱히 리턴하지않음.
        }

        transform.position = currentPos;
        //흔들고 나서 원래 포지션으로 귀환
    }
}

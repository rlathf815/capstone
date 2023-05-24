using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JYshakeCam : MonoBehaviour
{
    public float shakeTime = 2.0f;
    [Range(0.01f, 0.1f)]
    public float shakeIntensity = 0.05f;   
    [Range(0.10f, 0.30f)]
    public float shakeRange = 0.15f;
    
    public float waitingTimer = 1.0f;

    public bool isWait = false;
    public bool xActive = false;
    public bool yActive = false; 
    public bool zActive = false;

    private float x = 0;
    private float y = 0;
    private float z = 0;//기본적으론 0값. 액티브체크하면 값이 랜덤 shake로 바뀜

    // Start is called before the first frame update
    void Start()
    {
        
        //퍼블릭으로 true해놓으면 x y z축에 각각 shakeRange가 적용된 랜덤레인지 적용.
    }

    // Update is called once per frame
    void Update()
    {

        if (isWait && this.gameObject.activeSelf)
        {
            Waiting();
            shakeCamera(shakeTime, shakeIntensity);
        }else if (!isWait && this.gameObject.activeSelf)
        {
            shakeCamera(shakeTime, shakeIntensity);
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

    private IEnumerator Waiting()
    {
        yield return new WaitForSeconds(waitingTimer);
    }

    private IEnumerator ShakeCamPos()
    {
        Vector3 currentPos = transform.position;//초기값
        while(shakeTime > 0.0f)
        {
            if (xActive)
            {
                x = Random.Range(-shakeRange, shakeRange);
            }
            if (yActive)
            {
                y = Random.Range(-shakeRange, shakeRange);
            }
            if (zActive)
            {
                z = Random.Range(-shakeRange, shakeRange);
            }

            transform.position = currentPos + new Vector3(x, y, z) * shakeIntensity;

            //transform.position = currentPos + Random.insideUnitSphere * shakeIntensity;
            //발작이 심해서 버림.
            shakeTime -= Time.deltaTime;

            yield return null;
            //딱히 리턴하지않음.
        }

        transform.position = currentPos;
        //흔들고 나서 원래 포지션으로 귀환
    }
}

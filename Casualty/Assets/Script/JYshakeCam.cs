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
    private float z = 0;//�⺻������ 0��. ��Ƽ��üũ�ϸ� ���� ���� shake�� �ٲ�

    // Start is called before the first frame update
    void Start()
    {
        
        //�ۺ����� true�س����� x y z�࿡ ���� shakeRange�� ����� ���������� ����.
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
            //intensity 0.05�� ���� ���ٸ���.
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
        Vector3 currentPos = transform.position;//�ʱⰪ
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
            //������ ���ؼ� ����.
            shakeTime -= Time.deltaTime;

            yield return null;
            //���� ������������.
        }

        transform.position = currentPos;
        //���� ���� ���� ���������� ��ȯ
    }
}

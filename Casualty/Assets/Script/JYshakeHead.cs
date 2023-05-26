using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JYshakeHead : MonoBehaviour
{
    public float intervalMin = 0.1f; // �ּ� �ֱ�
    public float intervalMax = 1f; // �ִ� �ֱ�

    public GameObject head;

    private float timer; // �ֱ� Ÿ�̸�
    private float nextFlcikTime; // ���� ȸ�� �ð�

    private Quaternion crntR;

    void Start()
    {
        nextFlcikTime = GetNextTime();
        crntR = this.transform.rotation;
    }

    void Update()
    {
        float rnd = Random.Range(-5.0f, 5.0f);
        timer += Time.deltaTime;

        Quaternion newR = Quaternion.Euler(crntR.x, crntR.y + rnd, crntR.z);

        //�Ӹ��� ��Ÿ���� ��������ϸ鼭 �Ӹ��� ������
        if (timer >= nextFlcikTime)
        {
            if (head.activeSelf)
            {

                head.SetActive(false);
            }
            else if (head.activeSelf == false)
            {
                this.transform.rotation = newR;
                head.SetActive(true);
            }
            this.transform.rotation = crntR;
            //�����ֱ� ����
            nextFlcikTime = GetNextTime();
            timer = 0f;//Ÿ�̸ӵ� �ʱ�ȭ
        }
    }

    //�����ϰ� �ֱⰪ�� �޾ƿ��� �Լ�
    private float GetNextTime()
    {       
        return Random.Range(intervalMin, intervalMax);
    }
}

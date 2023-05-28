using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JYflickForLetter : MonoBehaviour
{
    public float intervalMin = 0.1f; // �ּ� �ֱ�
    public float intervalMax = 1f; // �ִ� �ֱ�

    public GameObject lightBulb;

    private float timer; // �ֱ� Ÿ�̸�
    private float nextFlcikTime; // ���� ȸ�� �ð�

    void Start()
    {

        nextFlcikTime = GetNextFlcikTime();
    }

    void Update()
    {
        timer += Time.deltaTime;

        //�����ϰ� �޾ƺ� �ֱ��� �����״��ϴ� ��ũ��Ʈ
        if (timer >= nextFlcikTime)
        {
            if (lightBulb.activeSelf)
            {

                lightBulb.SetActive(false);
            }
            else if (lightBulb.activeSelf == false)
            {

                lightBulb.SetActive(true);
            }

            //�����ֱ� ����
            nextFlcikTime = GetNextFlcikTime();
            timer = 0f;//Ÿ�̸ӵ� �ʱ�ȭ
        }
    }

    //�����ϰ� �ֱⰪ�� �޾ƿ��� �Լ�
    private float GetNextFlcikTime()
    {
        return Random.Range(intervalMin, intervalMax);
    }
}

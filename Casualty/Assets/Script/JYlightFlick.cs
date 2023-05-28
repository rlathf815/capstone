using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JYlightFlick : MonoBehaviour
{
    public float intervalMin = 0.1f; // �ּ� �ֱ�
    public float intervalMax = 1f; // �ִ� �ֱ�

    public GameObject lightBulb;
    private Renderer rend;
    private float timer; // �ֱ� Ÿ�̸�
    private float nextFlcikTime; // ���� ȸ�� �ð�

    void Start()
    {
        rend = GetComponent<Renderer>();
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
                rend.enabled = false;
                lightBulb.SetActive(false);
            }
            else if (lightBulb.activeSelf == false)
            {
                rend.enabled = true;
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

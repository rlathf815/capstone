using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndScroll : MonoBehaviour
{
    public float intervalMin = 0.1f; // �ּ� �ֱ�
    public float intervalMax = 0.5f; // �ִ� �ֱ�

    private int flicked = 5;
    public GameObject lightBulb;

    private float timer; // �ֱ� Ÿ�̸�
    private float nextFlcikTime; // ���� ȸ�� �ð�
    // Start is called before the first frame update
    void Start()
    {
        //�ӽ�
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 4.3f)
        {
            transform.position += Vector3.up * 0.15f * Time.deltaTime;
        }
        else if (transform.position.y > 4.3f)
        {
            timer += Time.deltaTime;
            if (timer >= nextFlcikTime && flicked > 0)
            {
                if (lightBulb.activeSelf)
                {                   
                    lightBulb.SetActive(false);
                    flicked--;
                }
                else if (lightBulb.activeSelf == false)
                {
                    lightBulb.SetActive(true);
                }
                
                //�����ֱ� ����
                nextFlcikTime = GetNextFlcikTime();
                timer = 0f;//Ÿ�̸ӵ� �ʱ�ȭ

            }
            
            if (flicked == 0)
            {
                StartCoroutine(End());
            }

        }

    }
    private float GetNextFlcikTime()
    {
        return Random.Range(intervalMin, intervalMax);
    }
    private IEnumerator End()
    {
        yield return new WaitForSeconds(3.0f);
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    
}

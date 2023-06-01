using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndScroll : MonoBehaviour
{
    public float intervalMin = 0.1f; // 최소 주기
    public float intervalMax = 0.5f; // 최대 주기

    private int flicked = 5;
    public GameObject lightBulb;

    private float timer; // 주기 타이머
    private float nextFlcikTime; // 다음 회전 시간
    // Start is called before the first frame update
    void Start()
    {
        //임시
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
                
                //랜덤주기 갱신
                nextFlcikTime = GetNextFlcikTime();
                timer = 0f;//타이머도 초기화

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

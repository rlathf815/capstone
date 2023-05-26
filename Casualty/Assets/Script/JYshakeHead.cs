using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JYshakeHead : MonoBehaviour
{
    public float intervalMin = 0.1f; // 최소 주기
    public float intervalMax = 1f; // 최대 주기

    public GameObject head;

    private float timer; // 주기 타이머
    private float nextFlcikTime; // 다음 회전 시간

    private Quaternion crntR;//기존 로테이션
    //private Vector3 crntScale;//기존 스케일

    void Start()
    {
        nextFlcikTime = GetNextTime();
        crntR = this.transform.rotation;
        //crntScale = this.transform.localScale;
    }

    void Update()
    {
        float rnd = Random.Range(-5.0f, 5.0f);
        //float Srnd = Random.Range(0.1f, 3f); scale관련 폐기
        timer += Time.deltaTime;

        Quaternion newR = Quaternion.Euler(crntR.x, crntR.y + rnd, crntR.z);
        //Vector3 newS = new Vector3(crntScale.x * Srnd, crntScale.y * Srnd, crntScale.z * Srnd);
        //머리가 나타났다 사라졌다하면서 머리가 움찔대는
        if (timer >= nextFlcikTime)
        {
            if (head.activeSelf)
            {
                head.SetActive(false);
            }
            else if (head.activeSelf == false)
            {
                this.transform.rotation = newR;
                //this.transform.localScale = newS;
                head.SetActive(true);
            }
            this.transform.rotation = crntR;
            //this.transform.localScale = crntScale;
            //랜덤주기 갱신
            nextFlcikTime = GetNextTime();
            timer = 0f;//타이머도 초기화
        }
    }

    //랜덤하게 주기값을 받아오는 함수
    private float GetNextTime()
    {       
        return Random.Range(intervalMin, intervalMax);
    }
}

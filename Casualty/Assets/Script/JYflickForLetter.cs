using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JYflickForLetter : MonoBehaviour
{
    public float intervalMin = 0.1f; // 최소 주기
    public float intervalMax = 1f; // 최대 주기

    public GameObject lightBulb;

    private float timer; // 주기 타이머
    private float nextFlcikTime; // 다음 회전 시간

    void Start()
    {

        nextFlcikTime = GetNextFlcikTime();
    }

    void Update()
    {
        timer += Time.deltaTime;

        //랜덤하게 받아본 주기대로 껐다켰다하는 스크립트
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

            //랜덤주기 갱신
            nextFlcikTime = GetNextFlcikTime();
            timer = 0f;//타이머도 초기화
        }
    }

    //랜덤하게 주기값을 받아오는 함수
    private float GetNextFlcikTime()
    {
        return Random.Range(intervalMin, intervalMax);
    }
}

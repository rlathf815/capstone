using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    // Flashlight //
    public GameObject flashlight;
    private bool isTurnOn = false;
    // 마우스 회전
    public float turnSpeed = 4.0f; // 마우스 회전 속도    
    private float xRotate = 0.0f; // 내부 사용할 X축 회전량은 별도 정의 ( 카메라 위 아래 방향 )
    public float moveSpeed = 4.0f; // 이동 속도
    public float jumpForce = 10.0f; // 점프하는 힘
    private bool isGround = true; // 땅에 붙어있는가?
    Rigidbody body; // Rigidbody를 가져올 변수


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();           // Rigidbody를 가져온다.
        transform.rotation = Quaternion.identity;   // 회전 상태를 정면으로 초기화
            
    }

    void FixedUpdate()
    {
        Move();
        Jump();
        Flashlight();
    }

    void Move()
    {
        // 좌우로 움직인 마우스의 이동량 * 속도에 따라 카메라가 좌우로 회전할 양 계산
        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
        // 현재 y축 회전값에 더한 새로운 회전각도 계산
        float yRotate = transform.eulerAngles.y + yRotateSize;

        // 위아래로 움직인 마우스의 이동량 * 속도에 따라 카메라가 회전할 양 계산(하늘, 바닥을 바라보는 동작)
        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
        // 위아래 회전량을 더해주지만 -45도 ~ 80도로 제한 (-45:하늘방향, 80:바닥방향)
        // Clamp 는 값의 범위를 제한하는 함수
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

        // 카메라 회전량을 카메라에 반영(X, Y축만 회전)
        transform.eulerAngles = new Vector3(xRotate, yRotate, 0);

        //  키보드에 따른 이동량 측정
        Vector3 move =
            transform.forward * Input.GetAxis("Vertical") +
            transform.right * Input.GetAxis("Horizontal");

        // 이동량을 좌표에 반영
        transform.position += move * moveSpeed * Time.deltaTime;
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && isGround)
        {
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            isGround = false;
        }
    }

    // 충돌 함수
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
    // On/Off Flashlight
    void Flashlight()
    {
        if (Input.GetKey(KeyCode.F))
        {
            flashlight.SetActive(isTurnOn);
            isTurnOn = !isTurnOn;
        }
    }
}

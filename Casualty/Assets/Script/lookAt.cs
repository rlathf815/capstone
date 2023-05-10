using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAt : MonoBehaviour
{
    public Transform player;
    public Transform LookatPlayer;
    public Animator animator;

    void Update()
    {
        transform.LookAt(player);

        // Vector3 currentRotation = transform.eulerAngles; // 객체 현 회전값

        Quaternion newRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
        //y값만 회전하고 나머지 (x는 앞뒤로 기울고, z는 왼쪽오른쪽으로 휙기움)는 고정.
        transform.rotation = newRotation;//적용

        animator.SetFloat("LookWeight", 1f);
    }

}

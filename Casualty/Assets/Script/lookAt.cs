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

        // Vector3 currentRotation = transform.eulerAngles; // ��ü �� ȸ����

        Quaternion newRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
        //y���� ȸ���ϰ� ������ (x�� �յڷ� ����, z�� ���ʿ��������� �ױ��)�� ����.
        transform.rotation = newRotation;//����

        animator.SetFloat("LookWeight", 1f);
    }

}

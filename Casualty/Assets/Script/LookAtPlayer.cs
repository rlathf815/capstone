using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform playerTransform;
    public float distance = 5.0f;
    public float speed = 5.0f;
    public float minDistance = 0.5f;//�󸶳� �پ����
    public float maxDistance = 1.0f;//�����Ÿ�
    public Vector3 velocity;
    private Animator animator;
    public float currentDistance;

    private float timer;

    public AudioSource audioSource;
    public AudioClip audioClip;

    public GameObject Player;
    private Rigidbody rb;

    private void Start()
    {


        animator = GetComponent<Animator>();
        animator.applyRootMotion = true;

        rb = Player.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        
        // �÷��̾� ������ �ٶ󺸵��� ȸ��
        Vector3 direction = playerTransform.position - transform.position;
        direction.y = 0;//y �𷺼��� ����.
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), speed * Time.deltaTime);

        // �����Ÿ��� �����ϸ� �÷��̾ ���� �̵�
        currentDistance = Vector3.Distance(transform.position, playerTransform.position);
        if(currentDistance > 12.0f)
        {//12�̻� �־����� ���۽����� �޷������鼭 �ѹ� ������.
            velocity = transform.forward * speed *1.2f;
        }
        else if (currentDistance <= 12.0f && currentDistance > maxDistance)
        {
            velocity = transform.forward * speed;
        }
        else if (currentDistance < minDistance)
        {
            velocity = -transform.forward * speed;
        }

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(velocity.x, rigidbody.velocity.y, velocity.z);

        if (timer <= 0.75f)
        {
            timer += Time.deltaTime;

        }else if(timer > 0.75f)
        {
            audioSource.PlayOneShot(audioClip);
            timer = 0f;
        }
    }


}

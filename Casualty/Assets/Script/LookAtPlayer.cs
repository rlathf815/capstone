using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public SharedData sharedData;//����� ������.

    public Transform playerTransform;
    public float distance = 5.0f;
    public float speed = 5.0f;
    public float minDistance = 1.5f;//�󸶳� �پ����
    public float maxDistance = 2.0f;//�����Ÿ�
    public Vector3 velocity;
    private Animator animator;
    public float currentDistance;

    public bool triggerGhost = false;//�ͽ��� �۵��ϰԵǴ� ��

    private float timer;

    public AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip Jumpscare_sound;

    public GameObject Player;
    private Rigidbody rb;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.applyRootMotion = true;
        sharedData.dillemaRunOver = false; // �������� ���徾 �ѹ� �ʱ�ȭ

        rb = Player.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Player.transform.position.x > -24)
        {
            //audioSource.PlayOneShot(Jumpscare_sound); �Ҹ��� ���ĳ��� ����
            triggerGhost = true;

            //����� ���̴°��������� �ͽ� Ȱ��ȭ
        }

        if (triggerGhost)
        {
            // �÷��̾� ������ �ٶ󺸵��� ȸ��
            Vector3 direction = playerTransform.position - transform.position;
            direction.y = 0;//y �𷺼��� ����.
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), speed * Time.deltaTime);

            // �����Ÿ��� �����ϸ� �÷��̾ ���� �̵�
            currentDistance = Vector3.Distance(transform.position, playerTransform.position);
            if (currentDistance > 12.0f)
            {//12�̻� �־����� ���۽����� �޷������鼭 �ѹ� ������.
                velocity = transform.forward * speed * 1.2f;
            }
            else if (currentDistance <= 12.0f && currentDistance > maxDistance)
            {
                velocity = transform.forward * speed;
            }
            
            if (currentDistance < minDistance && sharedData.dillemaRunOver == false)
            {
                sharedData.dillemaRunOver = true;
                velocity = -transform.forward * speed;
            }

            if (transform.position.x <= -132.5f)
            {//-133 x�������� �ͽ��� ���տ� �����ϴ°ǵ�, ���� ���� ħ����. ��� �ƿ� ���߰� �Ͽ���.
             //�߰��� �� ������¿��� ������ �ִϸ��̼��� �ִ����� ã�ƺ� ������.
                velocity = transform.forward * 0;
            }

            Rigidbody rigidbody = GetComponent<Rigidbody>();
            rigidbody.velocity = new Vector3(velocity.x, rigidbody.velocity.y, velocity.z);

            if (timer <= 0.75f)
            {
                timer += Time.deltaTime;

            }
            else if (timer > 0.75f)
            {
                audioSource.PlayOneShot(audioClip);
                timer = 0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sharedData.dillemaRunOver = true;//������ ����������.
            //���� �������ɾ� �������.
        }
    }


}
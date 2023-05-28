using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LookAtPlayer : MonoBehaviour
{
    public SharedData sharedData;//����� ������.

    public Transform playerTransform;
    public float distance = 5.0f;
    public float speed = 5.0f;
    public float minDistance = 1.5f;//�󸶳� �پ����
    public float maxDistance = 5.0f;//�����Ÿ�
    public Vector3 velocity;
    private Animator animator;
    public float currentDistance;

    public bool triggerGhost = false;//�ͽ��� �۵��ϰԵǴ� ��

    private float timer;

    public AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip Jumpscare_sound;

    private float animatorSpeed = 1.0f;

    public GameObject Player;
    //private Rigidbody rb;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.applyRootMotion = true;
        sharedData.dillemaRunOver = false; // �������� ���徾 �ѹ� �ʱ�ȭ

        //rb = Player.GetComponent<Rigidbody>();
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
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), speed*10 * Time.deltaTime);

            // �����Ÿ��� �����ϸ� �÷��̾ ���� �̵�
            currentDistance = Vector3.Distance(transform.position, playerTransform.position);
            if (transform.position.x <= -103f)
            {//-133 x�������� �ͽ��� ���տ� �����ϴ°ǵ�, ���� ���� ħ����. ��� �ƿ� ���߰� �Ͽ���.
             //�߰��� �� ������¿��� ������ �ִϸ��̼��� �ִ����� ã�ƺ� ������.
             //velocity = transform.forward * 0;
                animator.speed = 0f;
                transform.position += transform.forward * 0 * Time.deltaTime;
            }else if (currentDistance > maxDistance*3)
            {//5�̻� �־����� ���� ������.
                animatorSpeed = 2.0f;
                //velocity = transform.forward * speed * 1.2f;
                transform.position += transform.forward * speed * animatorSpeed * Time.deltaTime;
                animator.speed = animatorSpeed;
            }
            else if (currentDistance > maxDistance)
            {
                animatorSpeed = 1.5f;
                //velocity = transform.forward * speed;
                transform.position += transform.forward * speed* animatorSpeed * Time.deltaTime;
                animator.speed = animatorSpeed;
            }
            else if(currentDistance < maxDistance)
            {
                animatorSpeed = 1.0f;
                transform.position += transform.forward * speed *animatorSpeed* Time.deltaTime;
                animator.speed = animatorSpeed;
            }else if(currentDistance < 2.0f)
            {
                animatorSpeed = 2.0f;
                transform.position += transform.forward * speed * animatorSpeed * Time.deltaTime;
                animator.speed = animatorSpeed;
            }

            
            if (currentDistance < minDistance && sharedData.dillemaRunOver == false)
            {
                sharedData.dillemaRunOver = true;
                //velocity = -transform.forward * speed;
            }

            

            //Rigidbody rigidbody = GetComponent<Rigidbody>();
            //rigidbody.velocity = new Vector3(velocity.x, rigidbody.velocity.y, velocity.z);

            if (timer <= 0.75f * (1/animatorSpeed))
            {
                timer += Time.deltaTime;

            }
            else if (timer > 0.75f * (1 / animatorSpeed))
            {
                audioSource.PlayOneShot(audioClip);
                timer = 0f;
            }
        }

        if (sharedData.dillemaRunOver)
        {
            StartCoroutine(YouAreDead());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sharedData.dillemaRunOver = true;//������ ����������.
            this.transform.gameObject.SetActive(false);
            //���� �������ɾ� �������.
            //������!
        }
    }

    private IEnumerator YouAreDead()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("HorrorScene");
    }


}
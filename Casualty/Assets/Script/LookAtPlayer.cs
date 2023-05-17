using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public SharedData sharedData;//쉐어드 데이터.

    public Transform playerTransform;
    public float distance = 5.0f;
    public float speed = 5.0f;
    public float minDistance = 1.25f;//죽는거리
    public float maxDistance = 2.0f;//일정거리
    public Vector3 velocity;
    private Animator animator;
    public float currentDistance;

    public bool triggerGhost = false;//귀신이 작동하게되는 선

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
        sharedData.dillemaRunOver = false; // 딜레마씬 입장씨 한번 초기화

        rb = Player.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(Player.transform.position.x > -24)
        {
            //audioSource.PlayOneShot(Jumpscare_sound); 소리가 겹쳐나서 보류
            triggerGhost = true;
            //sharedData.dillemaRunOver = true;

            //계단이 보이는곳까지가면 귀신 활성화
        }

        if (triggerGhost)
        {
            // 플레이어 방향을 바라보도록 회전
            Vector3 direction = playerTransform.position - transform.position;
            direction.y = 0;//y 디렉션은 고정.
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), speed * Time.deltaTime);

            // 일정거리를 유지하며 플레이어를 따라 이동
            currentDistance = Vector3.Distance(transform.position, playerTransform.position);
            if (currentDistance > 12.0f)
            {//12이상 멀어지면 갑작스럽게 달려나오면서 한번 가속함.
                velocity = transform.forward * speed * 1.2f;
            }
            else if (currentDistance <= 12.0f && currentDistance > maxDistance)
            {
                velocity = transform.forward * speed;
            }
            else if (currentDistance < minDistance)
            {
                Debug.Log("close");
                System.Reflection.FieldInfo field = sharedData.GetType().GetField("dillemaRunOver");
                if (field != null && field.FieldType == typeof(bool))
                {
                    bool currentValue = (bool)field.GetValue(sharedData);
                    if (!currentValue)
                    {
                        field.SetValue(sharedData, true);
                        Debug.Log("Dead");
                    }
                }
                // sharedData.dillemaRunOver = true;
                velocity = -transform.forward * speed;
            }

            if (transform.position.x <= -132.5f)
            {//-133 x포지션이 귀신이 문앞에 도달하는건데, 가끔 문을 침범함. 고로 아예 멈추게 하였음.
             //추가로 이 멈춘상태에서 적절한 애니메이션이 있는지도 찾아볼 예정임.
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

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            System.Reflection.FieldInfo field = sharedData.GetType().GetField("dillemaRunOver");
            if (field != null && field.FieldType == typeof(bool))
            {
                bool currentValue = (bool)field.GetValue(sharedData);
                if (!currentValue)
                {
                    field.SetValue(sharedData, true);
                    Debug.Log("Dead");
                }
            }//닿으면 데이터전달.
            //아직 점프스케어 적용못함.
        }
    }
    */


}

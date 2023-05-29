using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public NavMeshAgent ai;

    // 이동경로 Scene 상에서 Destination 오브젝트
    // 0 -> 1 -> 2 -> 1 -> 3 -> 4 -> 3 -> 5 -> 0 반복
    public List<Transform> destinations;

    public List<GameObject> TeleportTargetObject;
    public Animator aiAnim;
    public float walkSpeed, chaseSpeed, idleTime, minIdleTime, maxIdleTime, sightDistance, catchDistance
        , chaseTime, minChaseTime, maxChaseTime, screamTime, attackTime;
    public AudioSource audioScream, audioChase, audioBackground, audioFootstep;
    // screaming: scream 하는 상태
    // screamed: 처음 한번만 scream 애니메이션 재생, 이후 chasing으로 진입해야함
    // attack은 모든 상태에서 전환될 수 있음
    public bool walking, chasing, screaming, screamed, attacking;
    public int destinationAmount, TeleportTargetAmount, targetDestinationIndex, teleportTargetIndex, endingSceneAmount;
    public GameObject player;
    public Vector3 rayCastOffset;

    public static bool isPlayerHiding = false;

    private Transform currentDest;
    private Vector3 dest;
    private float distance;
    private void Init()
    {
        attacking = false;
        screaming = false;
        screamed = false;
        walking = false;
        chasing = true;
        targetDestinationIndex = 0;
        teleportTargetIndex = 0;
        currentDest = destinations[targetDestinationIndex];
        audioFootstep.volume = 1.0f;
        audioBackground.volume = 0.75f;
        audioScream.volume = 0.75f;
        audioChase.volume = 0.75f;
    }
    private void Start()
    {
        Init();
    }
    private void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        checkRaycast();
        checkChasing();
        checkWalking();
        checkScream();
        isEnableToAttack();
        checkAttack();
    }
    private void checkRaycast()
    {
        if (player.activeSelf)
        {
            Vector3 direction = player.transform.position - transform.position;
            direction = direction.normalized;
            RaycastHit hit;
            if (Physics.Raycast(transform.position + rayCastOffset, direction, out hit, sightDistance))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    //Debug.Log("hit.collider.gameObject: " + hit.collider.gameObject.transform);
                    walking = false;
                    StopCoroutine("stayIdle");
                    StopCoroutine("chaseRoutine");
                    // 처음 player 적발시에만 바로 chasing 하지않고 screaming -> chasing
                    if (!screamed)
                    {

                        StartCoroutine("scream");
                        screaming = true;
                    }
                    else
                    {
                        StartCoroutine("chaseRoutine");
                        chasing = true;
                    }
                }
            }
        }
    }
    private void checkChasing()
    {
        if (chasing && distance >= catchDistance)
        {
            if (!audioChase.isPlaying)
            {
                audioBackground.Stop();
                audioChase.Play();
            }
            Debug.Log("chasing");
            StopCoroutine("attack");
            dest = player.transform.position;
            transform.LookAt(player.transform.position);
            ai.destination = dest;
            ai.speed = chaseSpeed;
            aiAnim.ResetTrigger("scream");
            aiAnim.ResetTrigger("walk");
            aiAnim.ResetTrigger("idle");
            aiAnim.ResetTrigger("attack");
            aiAnim.SetTrigger("chase");
        }
    }
    private void checkWalking()
    {
        if (walking)
        {
            if (!audioBackground.isPlaying)
                audioBackground.Play();
            screamed = false;
            //Debug.Log("walking");
            dest = currentDest.position;
            ai.destination = dest;
            ai.speed = walkSpeed;
            ai.transform.LookAt(dest);
            aiAnim.ResetTrigger("scream");
            aiAnim.ResetTrigger("chase");
            aiAnim.ResetTrigger("idle");
            aiAnim.ResetTrigger("attack");
            aiAnim.SetTrigger("walk");
            if (ai.remainingDistance <= ai.stoppingDistance)
            {
                aiAnim.ResetTrigger("chase");
                aiAnim.ResetTrigger("walk");
                aiAnim.SetTrigger("idle");
                ai.speed = 0;
                StopCoroutine("stayIdle");
                StartCoroutine("stayIdle");
                walking = false;
            }
        }
    }
    private void checkScream()
    {
        if (screaming)
        {
            Debug.Log("screaming");
            // 정지 상태에서 scream

            ai.speed = 0;
            transform.LookAt(player.transform.position);
            aiAnim.ResetTrigger("chase");
            aiAnim.ResetTrigger("idle");
            aiAnim.ResetTrigger("walk");
            aiAnim.ResetTrigger("attack");
            aiAnim.SetTrigger("scream");
            screaming = false;
        }
    }
    private void checkAttack()
    {

        if (attacking)
        {
            attacking = false;
            //Debug.Log("attacking");
            // 정지 상태에서 attack
            ai.speed = 0;
            transform.LookAt(player.transform.position);
            aiAnim.ResetTrigger("chase");
            aiAnim.ResetTrigger("idle");
            aiAnim.ResetTrigger("attack");
            aiAnim.ResetTrigger("walk");
            aiAnim.ResetTrigger("scream");
            aiAnim.SetTrigger("attack");
            chasing = true;
            StopCoroutine("attack");
        }
    }
    private void isEnableToAttack()
    {
        // 공격 범위 판정
        if (distance <= catchDistance)
        {
            // 캐비넷에 숨어있으면 공격판정 x
            // 바로 돌아가는게 아니라 앞에 잠깐 머물다 walking 상태로 돌아감
            if (isPlayerHiding && chasing) 
            {
                chasing = false;
                walking = false;
                // 캐비넷에 숨었을때는 플레이어 객체가 바뀐다.
                // 기존 플레이어 위치를 사용하면 사라진 플레이어 객체 위치를 기반으로 판단하게됨
                // 그러나 숨은 플레이어 객체는 캐비넷마다 다르게 구현되어있다. 따라서 메인 카메라 위치를 기반으로 판단
                // 캐비넷 앞에서 AI가 멈추게끔 구현하는게 자연스러움
                if (Vector3.Distance(transform.position, Camera.main.transform.forward) > 0.05f)
                {
                    ai.destination = Camera.main.transform.forward;
                }
                ai.speed = 0;
                aiAnim.ResetTrigger("chase");
                aiAnim.ResetTrigger("walk");
                aiAnim.SetTrigger("idle");
                StartCoroutine("stayIdle");
            }
            if (!isPlayerHiding) // 가까이 붙으면 잡힌걸로 판정, 숨은상태라면 Player객체 비활성화
            {
                //Debug.Log("catch, distance: " + distance);
                // 잡혔을때 주어진 위치로 이동 //
                chasing = false;
                StartCoroutine("attack");
                attacking = true;
            }
        }
    }
    // Scream Animation End frame - Animation Event
    private void PlayScreamAudio()
    {
        audioScream.Play();
       // Debug.Log("AI scream played");
    }
    private void PlayFootstep()
    {
        audioFootstep.Play();
    }
    private void ConvertScreamToChase()
    {
        if (!audioChase.isPlaying)
        {
            audioScream.Stop();
            audioChase.Play();
        }
    }
    // Attack Animation - Animation Event에서 사용
    private void teleport()
    {
        //Debug.Log("teleport");
        if(player.activeSelf)
        {
            StopAllCoroutines();
            chasing = true;
            attacking = false;
            aiAnim.SetTrigger("chase");
            StartCoroutine("chaseRoutine");
            if (teleportTargetIndex > TeleportTargetAmount)
            {
                teleportTargetIndex = 0;
                player.transform.position = TeleportTargetObject[teleportTargetIndex].transform.position;
                player.transform.rotation = TeleportTargetObject[teleportTargetIndex].transform.rotation;
                teleportTargetIndex++;
            }
            else
            {
                player.transform.position = TeleportTargetObject[teleportTargetIndex].transform.position;
                player.transform.rotation = TeleportTargetObject[teleportTargetIndex].transform.rotation;
                teleportTargetIndex++;
            }
        }

    }


    public void startChase() // use EndingSequenceStart.cs
    {
        screamed = true;
        screaming = false;
        walking = false;
        //Debug.Log("startChase() screamed: " + screamed);
        //Debug.Log("startChase() screaming: " + screaming);
        //Debug.Log("startChase() walking: " + walking);
        aiAnim.SetTrigger("chase");
        StartCoroutine("chaseRoutine");
        chasing = true;
        //Debug.Log("startChase() chasing: " + chasing);
    }
    public void stopChase()
    {
        walking = true;
        chasing = false;
        StopCoroutine("chaseRoutine");
        currentDest = destinations[targetDestinationIndex];
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("targetDestinationIndex: " + targetDestinationIndex);
        if (other.gameObject.tag == "Destination")
        {
            if (targetDestinationIndex < destinationAmount-1)
                targetDestinationIndex++;
            else
                targetDestinationIndex = 0;
        }
    }
    IEnumerator scream() // scream animation -> chase animation
    {
        yield return new WaitForSeconds(screamTime);
        screamed = true;
        chasing = true;
    }
    IEnumerator attack() // any state -> attack , attack -> chase
    {
        yield return new WaitForSeconds(attackTime);
        chasing = true;
        attacking = false;
    }
    IEnumerator stayIdle()
    {
        idleTime = Random.Range(minIdleTime, maxIdleTime);
        yield return new WaitForSeconds(idleTime);
        walking = true;
        currentDest = destinations[targetDestinationIndex];
    }
    IEnumerator chaseRoutine()
    {
        chaseTime = Random.Range(minChaseTime, maxChaseTime);
        yield return new WaitForSeconds(chaseTime);
        walking = true;
        chasing = false;
        currentDest = destinations[targetDestinationIndex];
    }
}
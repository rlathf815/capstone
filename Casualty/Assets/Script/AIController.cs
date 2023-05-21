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
        ,chaseTime, minChaseTime, maxChaseTime, screamTime, attackTime;

    // screaming: scream 하는 상태
    // screamed: 처음 한번만 scream 애니메이션 재생, 이후 chasing으로 진입해야함
    // attack은 모든 상태에서 전환될 수 있음
    public bool walking, chasing, screaming, screamed, attacking;
    public int destinationAmount, TeleportTargetAmount, targetDestinationIndex, teleportTargetIndex;
    public Transform player;
    public Vector3 rayCastOffset;
    private Transform currentDest;
    private Vector3 dest;
    private bool needTeleport, needTeleport2;

    private void Init()
    {
        attacking = false;
        screaming = false;
        screamed = false;
        chasing = false;
        walking = true;
        needTeleport = true;
        targetDestinationIndex = 0;
        teleportTargetIndex = 0;
        currentDest = destinations[targetDestinationIndex];

    }
    private void Start()
    {
        Init();
    }
    private void FixedUpdate()
    {
        #region Raycast
        Vector3 direction = player.position - transform.position;
        direction = direction.normalized;
        RaycastHit hit;
        if (Physics.Raycast(transform.position + rayCastOffset, direction, out hit, sightDistance))
        {
            if(hit.collider.gameObject.tag == "Player")
            {
                //Debug.Log("Player detected");
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
        #endregion

        #region chasing

        if (chasing)
        {
            dest = player.position;
            transform.LookAt(player.position);
            ai.destination = dest;
            ai.speed = chaseSpeed;
            aiAnim.ResetTrigger("scream");
            aiAnim.ResetTrigger("walk");
            aiAnim.ResetTrigger("idle");
            aiAnim.SetTrigger("chase");
        }
        #endregion

        #region walking
        if (walking)
        {
            //Debug.Log("walking");
            dest = currentDest.position;
            ai.destination = dest;
            ai.speed = walkSpeed;
            aiAnim.ResetTrigger("scream");
            aiAnim.ResetTrigger("chase");
            aiAnim.ResetTrigger("idle");
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
        #endregion

        #region screaming
        if (screaming) 
        {
            Debug.Log("screaming");
            // 정지 상태에서 scream
            ai.speed = 0;
            transform.LookAt(player.position);
            aiAnim.ResetTrigger("chase");
            aiAnim.ResetTrigger("idle");
            aiAnim.ResetTrigger("walk");
            aiAnim.SetTrigger("scream");
            screaming = false;
        }
        #endregion

        #region attacking

        if (attacking)
        {
            attacking = false;
            Debug.Log("attacking");
            // 정지 상태에서 attack
            ai.speed = 0;
            transform.LookAt(player.position);
            aiAnim.ResetTrigger("chase");
            aiAnim.ResetTrigger("idle");
            aiAnim.ResetTrigger("walk");
            aiAnim.ResetTrigger("scream");
            aiAnim.SetTrigger("attack");
        }

        #endregion

        #region check hit

        if (Vector3.Distance(transform.position, player.transform.position) <= catchDistance) // 가까이 붙으면 잡힌걸로 판정
        {
            // 잡혔을때 주어진 위치로 이동 //
            chasing = false;
            StartCoroutine("attack");
            attacking = true;
        }
        #endregion

    }

    private void teleport()
    {
        //Debug.Log("teleport");
        chasing = true;
        attacking = false;

        if (teleportTargetIndex > TeleportTargetAmount)
        {
            teleportTargetIndex = 0;
            player.position = TeleportTargetObject[teleportTargetIndex].transform.position;
            player.rotation = TeleportTargetObject[teleportTargetIndex].transform.rotation;
            teleportTargetIndex++;
        }
        else
        {
            player.position = TeleportTargetObject[teleportTargetIndex].transform.position;
            player.rotation = TeleportTargetObject[teleportTargetIndex].transform.rotation;
            teleportTargetIndex++;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (targetDestinationIndex <= destinationAmount)
            targetDestinationIndex++;
        else
            targetDestinationIndex = 0;
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
        attacking = false;
        chasing = true;
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
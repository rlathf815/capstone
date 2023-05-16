using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public NavMeshAgent ai;
    public List<Transform> destinations;
    public Animator aiAnim;
    public float walkSpeed, chaseSpeed, idleTime, minIdleTime, maxIdleTime, sightDistance, catchDistance
        ,chaseTime, minChaseTime, maxChaseTime,jumpscareTime, screamTime;
  

    public int destinationAmount;
    public bool walking, chasing,screaming;
    public Transform player;
    public Vector3 rayCastOffset;
    public string deathScene;



    private Transform currentDest;
    private Vector3 dest;
    private int randNum, randNum2;

    private void Start()
    {
        walking = true;
        screaming = true;
        randNum = Random.Range(0, destinationAmount);
        currentDest = destinations[randNum];
    }
    private void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction = direction.normalized;
        RaycastHit hit;
        if(Physics.Raycast(transform.position + rayCastOffset, direction, out hit, sightDistance))
        {
            if(hit.collider.gameObject.tag == "Player")
            {
                walking=false;
                StopCoroutine("stayIdle");
                StopCoroutine("chaseRoutine");
                StartCoroutine("chaseRoutine");
                aiAnim.ResetTrigger("walk");
                aiAnim.ResetTrigger("idle");
                aiAnim.ResetTrigger("scream");
                Debug.Log("scream");
                StopCoroutine("scream");
                Debug.Log("sprint");
                aiAnim.SetTrigger("sprint");
            }
        }
       
        if (chasing)
        {
            dest = player.position;
            ai.destination = dest;
            ai.speed = chaseSpeed;
            // 잡혔을 때 구현하려면 사용
            //if (ai.remainingDistance <= catchDistance)
            //{
            //    aiAnim.ResetTrigger("sprint");
            //    aiAnim.SetTrigger("jumpscare");
            //    StartCoroutine("captureRoutine");
            //    chasing = false;
            //}
        }
        if (walking)
        {
            dest = currentDest.position;
            ai.destination = dest;
            ai.speed = walkSpeed;
            if (ai.remainingDistance <= ai.stoppingDistance)
            {
                randNum2 = Random.Range(0, 2);
                if (randNum2 == 0) // 다음 목적지
                {
                    randNum = Random.Range(0, destinationAmount);
                    currentDest = destinations[randNum];
                }
                else if (randNum2 == 1) 
                {
                    aiAnim.ResetTrigger("walk");
                    aiAnim.SetTrigger("idle");
                    ai.speed = 0;
                    StopCoroutine("stayIdle");
                    StartCoroutine("stayIdle");
                    walking = false;
                }
            }
        }
    }
    IEnumerator scream()
    {
        yield return new WaitForSeconds(screamTime);
        aiAnim.ResetTrigger("idle");
        aiAnim.ResetTrigger("walk");
        
        aiAnim.SetTrigger("scream");
    }
    IEnumerator stayIdle()
    {
        idleTime = Random.Range(minIdleTime, maxIdleTime);
        yield return new WaitForSeconds(idleTime);
        walking = true;
        randNum = Random.Range(0, destinationAmount);
        currentDest = destinations[randNum];
        aiAnim.ResetTrigger("idle");
        aiAnim.SetTrigger("walk");
    }
    IEnumerator chaseRoutine()
    {
        chaseTime = Random.Range(minChaseTime, maxChaseTime);
        yield return new WaitForSeconds(chaseTime);
        walking = true;
        chasing = false;
        randNum = Random.Range(0, destinationAmount);
        currentDest = destinations[randNum];
        aiAnim.ResetTrigger("sprint");
        aiAnim.SetTrigger("walk");
    }
    // 잡혔을때 구현하려면 사용
    //IEnumerator captureRoutine()
    //{
    //    yield return new WaitForSeconds(jumpscareTime);
    //    SceneManager.LoadScene(deathScene);
    //}
}

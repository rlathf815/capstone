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
    public bool walking, chasing, screaming;
    public int targetDestinationIndex, destinationAmount;
    public Transform player;
    public Vector3 rayCastOffset;



    private Transform currentDest;
    private Vector3 dest;
    private int rand;

    private void Start()
    {
        walking = true;
        //screaming = true;
        targetDestinationIndex = 0;
        currentDest = destinations[targetDestinationIndex];
        destinationAmount = 9;
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
                //StartCoroutine("scream");
                StartCoroutine("chaseRoutine");
                chasing = true;
            }
        }
       
        if (chasing)
        {
            dest = player.position;
            ai.destination = dest;
            ai.speed = chaseSpeed;
            aiAnim.ResetTrigger("walk");
            aiAnim.ResetTrigger("idle");
            aiAnim.SetTrigger("sprint");
            // 잡혔을 때 구현하려면 사용
            //if (ai.remainingDistance <= catchDistance)
            //{
            //    player.gameObject.SetActive(false);
            //    aiAnim.ResetTrigger("walk");
            //    aiAnim.ResetTrigger("idle");
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
            aiAnim.ResetTrigger("sprint");
            aiAnim.ResetTrigger("idle");
            aiAnim.SetTrigger("walk");
            if (ai.remainingDistance <= ai.stoppingDistance)
            {
                aiAnim.ResetTrigger("sprint");
                aiAnim.ResetTrigger("walk");
                aiAnim.SetTrigger("idle");
                ai.speed = 0;
                
                StopCoroutine("stayIdle");
                StartCoroutine("stayIdle");
                walking = false;
            }
        }
    }
    private void SetNextDestination()
    {
        
        if (targetDestinationIndex <= destinationAmount)
        {
           // Debug.Log("SetNextDestination()-> next index: " + targetDestinationIndex);
            currentDest = destinations[targetDestinationIndex];
            
        }
        else // overflow, dest index reset
        {
          //  Debug.Log("SetNextDestination()-> targetDestinationIndex overflow");
            targetDestinationIndex = 0;
            currentDest = destinations[targetDestinationIndex];
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (targetDestinationIndex <= destinationAmount)
            targetDestinationIndex++;
        else
            targetDestinationIndex = 0;
    }
    //IEnumerator scream()
    //{
    //    yield return new WaitForSeconds(screamTime);
    //    aiAnim.ResetTrigger("idle");
    //    aiAnim.ResetTrigger("walk");

    //    aiAnim.SetTrigger("scream");
    //}
    IEnumerator stayIdle()
    {
        idleTime = Random.Range(minIdleTime, maxIdleTime);
        yield return new WaitForSeconds(idleTime);
        walking = true;
        
        SetNextDestination();

    }
    IEnumerator chaseRoutine()
    {
        chaseTime = Random.Range(minChaseTime, maxChaseTime);
        yield return new WaitForSeconds(chaseTime);
        walking = true;
        chasing = false;
        
        SetNextDestination();

    }
    // 잡혔을때 구현하려면 사용
    //IEnumerator captureRoutine()
    //{
    //    yield return new WaitForSeconds(jumpscareTime);
    //    SceneManager.LoadScene(deathScene);
    //}
}

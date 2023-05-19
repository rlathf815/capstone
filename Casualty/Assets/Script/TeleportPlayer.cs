using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject ai;

    private void OnTriggerEnter(Collider other) // 영안실로 이동
    {
        player.transform.position = this.gameObject.transform.GetChild(0).position;
        ai.GetComponent<AIController>().StopCoroutine("scream");
        ai.GetComponent<AIController>().StopCoroutine("attack");
        ai.GetComponent<AIController>().StopCoroutine("stayIdle");
        ai.GetComponent<AIController>().StopCoroutine("chaseRoutine");
        ai.GetComponent<AIController>().screamed = false;
        ai.GetComponent<AIController>().chasing = false;
        ai.GetComponent<AIController>().attacking = false;
        ai.GetComponent<AIController>().screaming = false;
        ai.GetComponent<AIController>().walking = true;
        ai.GetComponent<AIController>().StartCoroutine("stayIdle");
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHide : MonoBehaviour
{
    public GameObject hideText, stopHideText, player, hidingPlayer;
    public AIController aiController;
    public Transform aiTransform;
    bool hiding, interactable;
    public float loseDistance;
    void Start()
    {
        interactable = false;
        hiding = false;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            hideText.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            hideText.SetActive(false);
            interactable = false;
        }
    }
    void Update()
    {
        if (interactable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactable = false;
                hiding = true;
                hideText.SetActive(false);
                stopHideText.SetActive(true);
                hidingPlayer.SetActive(true);
                player.SetActive(false);

            }
        }
        if (hiding)
        {
            // 숨는 곳 앞까지 왔다가 돌아감
            if (Vector3.Distance(aiTransform.position, player.transform.position) < loseDistance) 
            {
                aiController.stopChase();
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                stopHideText.SetActive(false);
                player.SetActive(true);
                hidingPlayer.SetActive(false);
                hiding = false;
            }
        }
    }
}


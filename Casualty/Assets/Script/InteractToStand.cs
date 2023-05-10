using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractToStand : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public GameObject ui;
    //public Transform player;

    // public KeyCode standUpKey = KeyCode.E;

    // Update is called once per frame
    void Update()
    {
        if (ui != null && ui.gameObject.activeSelf)
        {
            if (Input.GetKey(KeyCode.E))
            {
                animator.SetTrigger("Interaction");
                //   transform.LookAt(player);
                //   animator.SetFloat("LookWeight", 1f);
                ui.SetActive(false);
            }
        }
    }
}

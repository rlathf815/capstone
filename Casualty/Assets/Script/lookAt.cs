using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAt : MonoBehaviour
{
    public Transform player;
    public Animator animator;

    void Update()
    {
        transform.LookAt(player);
        animator.SetFloat("LookWeight", 1f);
    }

}

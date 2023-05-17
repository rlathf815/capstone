using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorParameterControll3 : MonoBehaviour
{
    public SharedData shareData;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shareData.patient3)
            animator.SetBool("isHandled", true);
    }
}

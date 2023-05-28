using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JYfallOffAnim : MonoBehaviour
{
    public Animator anim;
    public LookAtPlayer lookAtPlayer;
    public GameObject Player;

    private AudioSource audioSource;

    private bool triggerFall = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        anim.SetBool("fallOff", false);
        triggerFall = false;
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!triggerFall && lookAtPlayer.triggerGhost)
        {
            StartCoroutine(sec());
            triggerFall = true;
            anim.SetBool("fallOff", true);
            //anim.Play("fallOffWardrobe");
            
        }
    }

    private IEnumerator sec()
    {
        yield return new WaitForSeconds(4.0f);

        audioSource.PlayOneShot(audioSource.clip);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ghost;
    public GameObject Player;
    public GameObject jump;

    private Rigidbody rb;

    public SharedData sharedData;
    void Start()
    {
        jump.SetActive(false);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(sharedData.dillemaRunOver == true && Player.transform.position.x > -134)
        {//¿‚«˚¿ª ∂ß
            jump.SetActive(true);
            //Quaternion rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y-180f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y - 180f, transform.rotation.z);
            
            {
                rb.AddForce(transform.forward * -30f, ForceMode.Force);

            }
        }
    }
}

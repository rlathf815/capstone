using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOne : MonoBehaviour
{
    public SharedData sharedData;
    public GameObject Alex;
    public GameObject Sarah;
    public GameObject SarahCorpse;
    public GameObject AlexCorpse;

    public GameObject UI;
   
    public AudioClip Heartbeat;
    public AudioSource heartbeat;
   
    public AudioClip Beep;
    public AudioSource beep;

    public AudioClip Dead;
    public AudioSource dead;

    // Start is called before the first frame update
    void Start()
    {
        heartbeat = GetComponent<AudioSource>();
        beep = GetComponent<AudioSource>();
        dead = GetComponent<AudioSource>();

        if (sharedData.dillemaPatient == 0)
        {
            Debug.Log("entered decision scene");
            Sarah.SetActive(true);
            Alex.SetActive(true);
            UI.SetActive(true);
           // heartbeat.PlayOneShot(Heartbeat);
           // beep.PlayOneShot(Beep);
        }
        else if(sharedData.dillemaPatient == 1) //saved Alex -> Sarah killed
        {
            Sarah.SetActive(false);
            SarahCorpse.SetActive(true);
            UI.SetActive(false);
        }
        else if(sharedData.dillemaPatient == 2 ) //saved Sarah -> Alex killed
        {
            Alex.SetActive(false);
            AlexCorpse.SetActive(true);

            UI.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

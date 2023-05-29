using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingSequenceStart : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator shutdown;
    public Animator camera;
    public Animator zombie;
    public GameObject scream;
    public GameObject ai;

    public AudioClip Scream_c;
    public AudioClip DoorShut_c;
    public AudioClip glass_c;

    public Camera mainCam;
    public Camera subCam;
    public AudioListener audioListener;


    public AIController controller;
    public GameObject pointLight1, pointLight2, pointLight3;
    public Renderer rend;
    
    private AudioSource audiosource;
    
    private bool screamed;

    void Start()
    {
        subCam.enabled = true;
        subCam = Camera.main;
        mainCam.enabled = false;

        camera.speed = 0.3f;
        shutdown.speed = 1.6f;
        scream.SetActive(true);
        ai.SetActive(false);
        //shutdown.SetTrigger("ShutdownOn");
        StartCoroutine(endingSequenceStart());

        mainCam.transform.LookAt(ai.transform);
        //mainCam.transform.position = new Vector3(-1.14f, 1.2f, 15.263f);
        audiosource = GetComponent<AudioSource>();

        screamed = false;
    }

    private IEnumerator endingSequenceStart()
    {

        yield return new WaitForSeconds(0.9f);
        zombie.SetTrigger("scream");
       // yield return new WaitForSeconds(0.2f);
        // if(!screamed)
        // {
        //     Debug.Log("Scream.Play()");
        //     screamed = true;
        //     Scream.Play();
        // }

        audiosource.PlayOneShot(Scream_c);


        yield return new WaitForSeconds(0.8f);
        //DoorShut.Play();
        
        audiosource.PlayOneShot(DoorShut_c);
        yield return new WaitForSeconds(1.0f);
        audiosource.PlayOneShot(glass_c); 
        yield return new WaitForSeconds(0.2f);

        pointLight1.SetActive(false);
        pointLight2.SetActive(false);
        pointLight3.SetActive(false);
        rend.enabled = false;

        yield return new WaitForSeconds(0.8f);

        shutdown.SetTrigger("ShutdownOn");
        yield return new WaitForSeconds(2.0f);


        mainCam.enabled = true;
        mainCam = Camera.main;
        subCam.enabled = false;


        yield return new WaitForSeconds(0.1f);
        scream.SetActive(false);
        ai.SetActive(true);
        //Debug.Log("AI Scream");
        audioListener.enabled = false;
        controller.startChase();
    }
}

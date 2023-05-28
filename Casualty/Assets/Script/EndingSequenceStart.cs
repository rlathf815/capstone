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
    public GameObject mainCam;
    public GameObject subCam;
    public AudioClip Scream_c;
    public AudioClip DoorShut_c;
    public AIController controller;

    private AudioSource Scream;
    private AudioSource DoorShut;


    void Start()
    {
        mainCam.SetActive(false);
        subCam.SetActive(true);
        camera.speed = 0.3f;
        shutdown.speed = 1.6f;
        scream.SetActive(true);
        ai.SetActive(false);
        //shutdown.SetTrigger("ShutdownOn");
        StartCoroutine(endingSequenceStart());
        mainCam.transform.position = new Vector3(-1.14f, 1.2f, 15.263f);
        Scream = GetComponent<AudioSource>();
        DoorShut = GetComponent<AudioSource>();


    }

    private IEnumerator endingSequenceStart()
    {

        yield return new WaitForSeconds(0.5f);
        zombie.SetTrigger("scream");
        yield return new WaitForSeconds(0.6f);

        yield return new WaitForSeconds(2.0f);
        DoorShut.Play();
        yield return new WaitForSeconds(0.5f);

        shutdown.SetTrigger("ShutdownOn");
        yield return new WaitForSeconds(2.0f);

        mainCam.SetActive(true);
        subCam.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        scream.SetActive(false);
        ai.SetActive(true);
        controller.startChase();
    }
}

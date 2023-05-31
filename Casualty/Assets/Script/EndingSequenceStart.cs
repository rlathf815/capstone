using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public GameObject subtitle;
    public CanvasGroup canvasGroup;

    public TextMeshProUGUI uiTimerText;
    public TextMeshProUGUI uiTimerInfoText;
    public GameObject timerUI;

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

        // 여기다가 조건문으로,,isCaught false면 오프닝장면부터, true면 검은화면부터,,,
        // 검은화면은 blackoutimage 하나 만들고 UIFade로 넣으면될듯
        // 시작할때 나오는 자막은 chasing(GameObject s, CanvasGroup c) 파라미터로 전달

        StartCoroutine(endingSequenceStart());

        mainCam.transform.LookAt(ai.transform);
        //mainCam.transform.position = new Vector3(-1.14f, 1.2f, 15.263f);
        audiosource = GetComponent<AudioSource>();

        screamed = false;
    }
    private IEnumerator UIFade(GameObject gameobject, CanvasGroup canvasGroup)
    {
        gameobject.SetActive(true);

        canvasGroup.alpha = 0f;
        while (canvasGroup.alpha < 1f)
        {
            canvasGroup.alpha += Time.deltaTime / 0.7f;
            yield return null;
        }
        canvasGroup.alpha = 1f;

        yield return new WaitForSeconds(2f);

        while (canvasGroup.alpha > 0f)
        {
            canvasGroup.alpha -= Time.deltaTime / 0.7f;
            yield return null;
        }
        canvasGroup.alpha = 0f;

        gameobject.SetActive(false);
    }
    private IEnumerator CountdownTimer()
    {
        int timeRemaining = 60;

        while (timeRemaining > 0)
        {          
            uiTimerText.text = timeRemaining.ToString();

            yield return new WaitForSeconds(1f);

            timeRemaining--;
        }
        if(timeRemaining == 0)
        {
            uiTimerText.text = " ";
            uiTimerInfoText.text = "Gate has opened, run to survive";
        }

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
        StartCoroutine(chasing(subtitle, canvasGroup));
        

    }
    private IEnumerator chasing(GameObject s, CanvasGroup c)
    {
        StartCoroutine(UIFade(s, c));

        yield return new WaitForSeconds(0.1f);
        scream.SetActive(false);
        ai.SetActive(true);
        //Debug.Log("AI Scream");
        audioListener.enabled = false;
        controller.startChase();
        timerUI.SetActive(true);
        StartCoroutine(CountdownTimer());
        yield return new WaitForSeconds(58.0f);
        audiosource.PlayOneShot(DoorShut_c);
        yield return new WaitForSeconds(2.0f);

        shutdown.SetTrigger("OpenGate");
    }
}

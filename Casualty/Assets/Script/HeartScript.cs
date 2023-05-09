using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartScript : MonoBehaviour
{
    private float timer = 0.0f;
    private float beat = 0.5f;
    public int success = 0;
    private bool spaced = false;

    public bool HeartSuccess = false;//CPR씬 불 리턴
    //사운드관련

    public AudioClip heartBeat;//박동소리
    public AudioClip beeping;//심장 되살아나는 소리(10회부터)
    public AudioClip flatline;//flatline= 심장이 멈추면 일자로 선이 그어져서 플랫라인 삐-
    private AudioSource audioSource1;
    private AudioSource audioSource2;
    private AudioSource audioSource3;


    public float animationLength = 1f;

    private float timeElapsed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource1 = transform.GetChild(0).GetComponent<AudioSource>();
        audioSource2 = transform.GetChild(1).GetComponent<AudioSource>();
        audioSource3 = transform.GetChild(2).GetComponent<AudioSource>();

        audioSource1.clip = heartBeat;
        audioSource1.volume = 1.0f;

        audioSource2.clip = beeping;
        audioSource2.loop = true;
        audioSource2.volume = 0.0f;

        audioSource3.clip = flatline;
        audioSource3.loop = true;
        audioSource3.volume = 0.1f;
        
        audioSource2.Play();
        audioSource3.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
        // 60프레임으로 갱신
        timeElapsed += Time.deltaTime * 60f;

        if (timeElapsed >= animationLength * 15f && Input.GetKeyDown(KeyCode.Space) && spaced == false)
        {//20~30프레임사이에 스페이스바를 누르면
            success++;
            spaced = true;//여러번 체크 방지
            Debug.Log("Success");
        }
        // 30프레임마다 타이머 리셋
        if (timeElapsed >= animationLength * 30f)
        {
            audioSource1.PlayOneShot(heartBeat);
            timeElapsed = 0f;
            spaced = false;
            Debug.Log("Reset");
        }

        if(success == 10)
        {
            audioSource3.Stop();
            audioSource2.volume = 1.0f;
        }

        if(success >= 20)
        {// 20번 박동을 맞추면 통과, bool true되면 씬전환
            HeartSuccess = true;
        }
    }

}

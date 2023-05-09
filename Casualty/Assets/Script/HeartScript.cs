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

    public bool HeartSuccess = false;//CPR�� �� ����
    //�������

    public AudioClip heartBeat;//�ڵ��Ҹ�
    public AudioClip beeping;//���� �ǻ�Ƴ��� �Ҹ�(10ȸ����)
    public AudioClip flatline;//flatline= ������ ���߸� ���ڷ� ���� �׾����� �÷����� ��-
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
        
        // 60���������� ����
        timeElapsed += Time.deltaTime * 60f;

        if (timeElapsed >= animationLength * 15f && Input.GetKeyDown(KeyCode.Space) && spaced == false)
        {//20~30�����ӻ��̿� �����̽��ٸ� ������
            success++;
            spaced = true;//������ üũ ����
            Debug.Log("Success");
        }
        // 30�����Ӹ��� Ÿ�̸� ����
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
        {// 20�� �ڵ��� ���߸� ���, bool true�Ǹ� ����ȯ
            HeartSuccess = true;
        }
    }

}

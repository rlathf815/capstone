using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpScare : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject ghost;  
    //public GameObject eyeUI;
    //public GameObject deadPos;

    public Camera playerCam;
    public Camera deathCam;
    //��ȯ�� ī�޶�

    public SharedData sharedData;

    public GameObject jump;//����� ģ��
    public GameObject pushGhost;
    void Start()
    {
        sharedData.glitchOn = false;
        deathCam.gameObject.SetActive(false);
        //eyeUI.SetActive(false);
        jump.SetActive(false);
        pushGhost.gameObject.SetActive(false);
        //�����̵� �ִϸ��̼��� ������ �ƴ϶� �ѹ��� ���

    }

    // Update is called once per frame
    void Update()
    {
        if(sharedData.dillemaRunOver == true && this.transform.position.x > -103)
        {//������ ��

            //Quaternion rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y-180f, transform.rotation.z);
            //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y - 180f, transform.rotation.z);
            //transform.rotation = Quaternion.LookRotation(ghost.transform.position);

            //this.transform.LookAt(ghost.transform);//�ܼ� ��ܸ� ���� �������� ���ƿ���, �ٸ� ȸ������ ���� ����.
            //rb.AddForce(transform.forward * -30f, ForceMode.Force);
            //ȸ�����Ѽ� �����ϴ°� �̷����� ������ �� �־ ���ο� ���� ���� �ű⼭ ����

            //eyeUI.SetActive(true);  


            //���� �ڵ��
            jump.SetActive(true);
            pushGhost.gameObject.SetActive(true);

            playerCam.enabled = false;
            deathCam.gameObject.SetActive(true);
            deathCam.enabled = true;
            sharedData.glitchOn = true;
        }
    }
}

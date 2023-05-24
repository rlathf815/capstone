using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpScare : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject ghost;
    public GameObject jump;
    //public GameObject eyeUI;
    //public GameObject deadPos;

    public Camera playerCam;
    public Camera deathCam;

    public SharedData sharedData;
    void Start()
    {
        deathCam.gameObject.SetActive(false);
        //eyeUI.SetActive(false);
        jump.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(sharedData.dillemaRunOver == true && this.transform.position.x > -134)
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

            playerCam.enabled = false;
            deathCam.gameObject.SetActive(true);
            deathCam.enabled = true;
        }
    }
}

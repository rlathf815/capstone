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
    //전환될 카메라

    public SharedData sharedData;

    public GameObject jump;//정가운데 친구
    public GameObject pushGhost;
    void Start()
    {
        sharedData.glitchOn = false;
        deathCam.gameObject.SetActive(false);
        //eyeUI.SetActive(false);
        jump.SetActive(false);
        pushGhost.gameObject.SetActive(false);
        //꿈찔이들 애니메이션이 루프가 아니라서 한번만 사용

    }

    // Update is called once per frame
    void Update()
    {
        if(sharedData.dillemaRunOver == true && this.transform.position.x > -103)
        {//잡혔을 때

            //Quaternion rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y-180f, transform.rotation.z);
            //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y - 180f, transform.rotation.z);
            //transform.rotation = Quaternion.LookRotation(ghost.transform.position);

            //this.transform.LookAt(ghost.transform);//단순 룩앳만 쓰면 공중으로 날아오름, 다만 회전값은 가장 좋음.
            //rb.AddForce(transform.forward * -30f, ForceMode.Force);
            //회전시켜서 보려하는게 이런저런 문제가 좀 있어서 새로운 구역 만들어서 거기서 연출

            //eyeUI.SetActive(true);  


            //이전 코드들
            jump.SetActive(true);
            pushGhost.gameObject.SetActive(true);

            playerCam.enabled = false;
            deathCam.gameObject.SetActive(true);
            deathCam.enabled = true;
            sharedData.glitchOn = true;
        }
    }
}

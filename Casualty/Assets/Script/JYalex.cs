using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JYalex : MonoBehaviour
{
    public SharedData sharedData;//알렉스가 죽은 2일때 발동하도록, 알렉스가 사는건 1.

    public Image UI;
    public GameObject Alex;

    public GameObject Player;
    public GameObject Ghost;

    public GameObject bloodTxt;

    private bool activeAlex;
    private bool deactiveAlex;

    public LookAtPlayer lookAtPlayer;

    // Start is called before the first frame update
    void Start()
    {
        activeAlex = false;
        deactiveAlex = false;

        //

        bloodTxt.SetActive(false);
        Alex.SetActive(false);
        UI.gameObject.SetActive(false);
        lookAtPlayer = Ghost.GetComponent<LookAtPlayer>();
        //초기화

        if(isAlexAlive())
        {//알렉스를 죽인게 아니면
            this.gameObject.SetActive(false);
            //스크립트 실행안함.
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(lookAtPlayer.triggerGhost && Player.transform.position.x < -44 && !deactiveAlex)
        {
            Alex.SetActive(true);//복도앞부터 활성화
            //알아서 대머리들이 보글보글거림.(프리팹으로 shakeHead.cs되어있음.)
            activeAlex = true;//알렉스 활성화
            if (activeAlex && Player.transform.position.z < 21f)
            {//알렉스가 한번 켜진 상태로 그 복도 중간에 서면 꺼짐.
                deactiveAlex = true;
                activeAlex = false;
                //한번만 발동하게 함.

                StartCoroutine(pass()); 
                bloodTxt.SetActive(true);

            }
        }

        
    }

    private IEnumerator pass()
    {
 

        UI.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        UI.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        UI.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.125f);
        UI.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        UI.gameObject.SetActive(true);
        Alex.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        UI.gameObject.SetActive(false);
       

        //화면이 점멸하다가 어두워졌을때 알렉스가 사라지고 밝아짐.
    }

    private bool isAlexAlive()
    {
        if(sharedData.dillemaPatient == 1)
        {
            return true;
        }
        else
        {
            return false;
        }        
    }
}

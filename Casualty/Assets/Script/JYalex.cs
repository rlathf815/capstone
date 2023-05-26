using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JYalex : MonoBehaviour
{
    public SharedData sharedData;//�˷����� ���� 2�϶� �ߵ��ϵ���, �˷����� ��°� 1.

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
        //�ʱ�ȭ

        if(isAlexAlive())
        {//�˷����� ���ΰ� �ƴϸ�
            this.gameObject.SetActive(false);
            //��ũ��Ʈ �������.
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(lookAtPlayer.triggerGhost && Player.transform.position.x < -44 && !deactiveAlex)
        {
            Alex.SetActive(true);//�����պ��� Ȱ��ȭ
            //�˾Ƽ� ��Ӹ����� ���ۺ��۰Ÿ�.(���������� shakeHead.cs�Ǿ�����.)
            activeAlex = true;//�˷��� Ȱ��ȭ
            if (activeAlex && Player.transform.position.z < 21f)
            {//�˷����� �ѹ� ���� ���·� �� ���� �߰��� ���� ����.
                deactiveAlex = true;
                activeAlex = false;
                //�ѹ��� �ߵ��ϰ� ��.

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
       

        //ȭ���� �����ϴٰ� ��ο������� �˷����� ������� �����.
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

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

    private bool activeAlex;
    private bool deactiveAlex;

    public LookAtPlayer lookAtPlayer;

    // Start is called before the first frame update
    void Start()
    {
        activeAlex = false;
        deactiveAlex = false;

        Alex.SetActive(false);
        UI.gameObject.SetActive(false);
        lookAtPlayer = Ghost.GetComponent<LookAtPlayer>();

        if(isNotAlexDead())
        {//�˷����� ���ΰ� �ƴϸ�
            this.gameObject.SetActive(false);
            //�Լ� �������.
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(lookAtPlayer.triggerGhost && Player.transform.position.x < -44 && !deactiveAlex)
        {
            Alex.SetActive(true);//�����պ��� Ȱ��ȭ
            activeAlex = true;
            if (activeAlex && Player.transform.position.z < 21f)
            {
                deactiveAlex = true;
                activeAlex = false;


                StartCoroutine(pass());

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
        yield return new WaitForSeconds(0.25f);
        UI.gameObject.SetActive(false);
        Alex.SetActive(false);
    }

    private bool isNotAlexDead()
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

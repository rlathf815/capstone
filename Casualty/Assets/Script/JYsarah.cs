using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JYsarah : MonoBehaviour
{
    public SharedData sharedData;//��� ���� 1�϶� �ߵ�, ��� ��°� 2.

    public Image UI;
    public GameObject Sarah;//������ ���
    public GameObject upSarah;//���߿� ���� ������ ���

    public GameObject all;

    public GameObject Player;
    public GameObject Ghost;
    public GameObject bloodTxt;

    private bool activeSarah;
    private bool deactiveSarah;

    private float coroutineTimer = 1.0f;

    public LookAtPlayer lookAtPlayer;

    // Start is called before the first frame update
    void Start()
    {
        all.SetActive(false);
        activeSarah = false;
        deactiveSarah = false;

        bloodTxt.SetActive(false);
        Sarah.SetActive(false);
        upSarah.SetActive(false);
        UI.gameObject.SetActive(false);
        lookAtPlayer = Ghost.GetComponent<LookAtPlayer>();
        //�ʱ�ȭ

        if (isSarahAlive())
        {//��� ��� ���������� ��ũ��Ʈ �������.
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(lookAtPlayer.triggerGhost && Player.transform.position.x < -44 && !deactiveSarah)
        {
            all.SetActive(true);
            Sarah.SetActive(true);
            Debug.Log("x");
            activeSarah = true; //��� �ߵ�.
            if(activeSarah && Player.transform.position.z < 24f)
            {
                Debug.Log("z");
                deactiveSarah = true;
                activeSarah = false;

                StopCoroutine(pass());
                StartCoroutine(pass());
                bloodTxt.SetActive(true);     
                
            }
            
        }
    }

    private void onoffSarah()
    {
        if (Sarah.activeSelf)
        {
            upSarah.SetActive(true);
            Sarah.SetActive(false);
        }else if (!Sarah.activeSelf)
        {
            upSarah.SetActive(false);
            Sarah.SetActive(true);
        }
    }

    private IEnumerator sec()
    {
        yield return new WaitForSeconds(0.2f);
    }

    private IEnumerator pass()
    {

        UI.gameObject.SetActive(true);//����
        onoffSarah();

        yield return new WaitForSeconds(0.2f);
        UI.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        UI.gameObject.SetActive(true);//����
        onoffSarah();


        yield return new WaitForSeconds(0.1f);
        UI.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        UI.gameObject.SetActive(true);//����
        onoffSarah();
        yield return new WaitForSeconds(0.1f);
        UI.gameObject.SetActive(false);
        Debug.Log("glitchon");
        sharedData.glitchOn = true;
        
        yield return new WaitForSeconds(0.05f);
        onoffSarah();
        yield return new WaitForSeconds(0.05f);
        onoffSarah();
        yield return new WaitForSeconds(0.05f);
        onoffSarah();
        yield return new WaitForSeconds(0.05f);
        onoffSarah();
        yield return new WaitForSeconds(0.05f);
        onoffSarah();
        yield return new WaitForSeconds(0.05f);
        onoffSarah();
        yield return new WaitForSeconds(0.05f);
        onoffSarah();


        yield return new WaitForSeconds(0.2f);
        Debug.Log("glitchoff");
        sharedData.glitchOn = false;
        all.SetActive(false);
    }

    private bool isSarahAlive()
    {
        if (sharedData.dillemaPatient == 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

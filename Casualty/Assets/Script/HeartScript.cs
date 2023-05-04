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
    private bool completeGame = false;


    public float animationLength = 1f;

    private float timeElapsed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        spaced = false;
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
            timeElapsed = 0f;
            spaced = false;
            Debug.Log("Reset");
        }

        if(success >= 20)
        {// 20�� �ڵ��� ���߸� ���, bool true�Ǹ� ����ȯ
            completeGame = true;
        }
    }

}

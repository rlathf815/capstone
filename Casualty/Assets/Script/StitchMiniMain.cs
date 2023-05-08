using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;//textmeshpro

public class StitchMiniMain : MonoBehaviour
{
    private int BloodLoss = 10;//�Ϲ������� ������ �Ҵ� �ӵ�

    public TextMeshProUGUI healthText;//���� HP���� ����� TextMeshpro
    private Image cutImage;
    public bool iscut = false;


    public Slider hpbar;
    public float maxHp=10000f;
    public float currenthp = 10000f;//hp
    // Start is called before the first frame update
    void Start()
    {
        Canvas myCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        cutImage = myCanvas.transform.Find("Cut_Through").GetComponent<Image>();
    }

    public void UpdateHealthText(float newHealth)
    {
        //float�� int�� ��ȯ
        int health = (int)newHealth;
        //int�� string���� ��ȯ
        string stringHealth = health.ToString();
        healthText.text = stringHealth + "ml";
    }

    // Update is called once per frame
    void Update()
    {
        currenthp -= Time.deltaTime * BloodLoss * 1f;
        hpbar.value = currenthp;
        UpdateHealthText(currenthp);

        if (cutImage.gameObject.activeSelf == false)
        {//���� �� ���� �Ҵ� �ӵ� ����
            iscut = true;
            BloodLoss = 25;
        }
    }
}

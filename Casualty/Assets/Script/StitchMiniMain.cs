using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;//textmeshpro

public class StitchMiniMain : MonoBehaviour
{
    private int BloodLoss = 10;//일반적으로 혈액을 잃는 속도

    public TextMeshProUGUI healthText;//현재 HP값을 출력할 TextMeshpro
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
        //float을 int로 변환
        int health = (int)newHealth;
        //int를 string으로 변환
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
        {//절개 후 혈액 잃는 속도 증가
            iscut = true;
            BloodLoss = 25;
        }
    }
}

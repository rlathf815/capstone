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

        // 60프레임으로 갱신
        timeElapsed += Time.deltaTime * 60f;

        if (timeElapsed >= animationLength * 15f && Input.GetKeyDown(KeyCode.Space) && spaced == false)
        {//20~30프레임사이에 스페이스바를 누르면
            success++;
            spaced = true;//여러번 체크 방지
            Debug.Log("Success");
        }
        // 30프레임마다 타이머 리셋
        if (timeElapsed >= animationLength * 30f)
        {
            timeElapsed = 0f;
            spaced = false;
            Debug.Log("Reset");
        }

        if(success >= 20)
        {// 20번 박동을 맞추면 통과, bool true되면 씬전환
            completeGame = true;
        }
    }

}

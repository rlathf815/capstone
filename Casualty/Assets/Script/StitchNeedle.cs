using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StitchNeedle : MonoBehaviour
{
    public Image StitchLine;
    public TextMeshProUGUI StitchText;

    public bool SuceessStitch = false;// 게임완료 bool;

    public Vector3 GauzePos;

    public GameObject Guts;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GauzePos = this.gameObject.transform.position;

        if (StitchLine.gameObject.activeSelf && (GauzePos.x >= -1.2f && GauzePos.x <= -1.1f) && (GauzePos.z <= 0.14f && GauzePos.z >= 0.08f))
        {
            StitchText.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SuceessStitch = true;//StitchScene
                                     //성공 true 리턴
                Destroy(StitchText);
                Destroy(StitchLine, 2.0f);
                Destroy(Guts);
            }
        }
        else
        {
            StitchText.gameObject.SetActive(false);
        }
    }
}

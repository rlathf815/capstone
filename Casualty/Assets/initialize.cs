using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initialize : MonoBehaviour
{
    public SharedData sharedData;
    public GameObject blackout;
    public GameObject Teamname;
    public CanvasGroup blackoutCv;
    public CanvasGroup teamnameCv;

    // Start is called before the first frame update
    void Start()
    {
        blackout.SetActive(true);
        StartCoroutine(UIFade());
        sharedData.initial = true;
        sharedData.patient1 = false;
        sharedData.patient2 = false;
        sharedData.patient3 = false;
        sharedData.dillemaPatient = 0;
        sharedData.dillemaRunOver = false;
        sharedData.bodyParked = false;
        sharedData.HorrorInitial = true;
        sharedData.hasEntered = false;
        sharedData.horrorPatient = false;
        sharedData.horrorPatient2 = false;
        sharedData.bodyParked2 = false;
        sharedData.isCaught = false;
        sharedData.index = 0;
        sharedData.glitchOn = false;
        
    }             

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator UIFade()
    {
        Teamname.SetActive(true);
        teamnameCv.alpha = 0f;
        yield return new WaitForSeconds(0.5f);

        while (teamnameCv.alpha < 1f)
        {
            teamnameCv.alpha += Time.deltaTime / 1.0f;
            yield return null;
        }
        teamnameCv.alpha = 1f;
        sharedData.glitchOn = true;
        yield return new WaitForSeconds(1f);
        sharedData.glitchOn = false;

        while (teamnameCv.alpha > 0f)
        {
            teamnameCv.alpha -= Time.deltaTime / 1.0f;
            //blackoutCv.alpha -= Time.deltaTime / 0.7f;
            yield return null;
        }

        teamnameCv.alpha = 0f;
        yield return new WaitForSeconds(0.6f);
        while (blackoutCv.alpha > 0f)
        {
            blackoutCv.alpha -= Time.deltaTime / 0.7f;
            yield return null;
        }
       

        blackoutCv.alpha = 0f;

        blackout.SetActive(false);
        Teamname.SetActive(false);
    }
}

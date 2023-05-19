using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillOne : MonoBehaviour
{
    public SharedData sharedData;
    public GameObject Alex;
    public GameObject Sarah;
    public GameObject SarahCorpse;
    public GameObject AlexCorpse;

    public GameObject Alex_blood;
    public GameObject Sarah_blood;

    public GameObject Alex_sleeping;
    public GameObject Sarah_sleeping;

    public GameObject UI;
   
    public AudioClip Heartbeat;
    public AudioSource heartbeat;
   
    public AudioClip Beep;
    public AudioSource beep;

    public AudioClip Dead;
    public AudioSource dead;

    public AudioClip Glitch;
    public AudioSource glitch;

    public GameObject AlexDead;
    public GameObject AlexKilled;
    public GameObject SarahDead;
    public GameObject SarahKilled;

    public JYlightFlick Flick;


    // Start is called before the first frame update
    void Start()
    {
        if (sharedData.dillemaPatient == 0)
        {
            Debug.Log("entered decision scene");
            Sarah.SetActive(true);
            Alex.SetActive(true);
            UI.SetActive(true);
           // heartbeat.PlayOneShot(Heartbeat);
           // beep.PlayOneShot(Beep);
        }
        else if(sharedData.dillemaPatient == 1) //saved Alex -> Sarah killed
        {
            Sarah.SetActive(false);
            Alex.SetActive(false);
            Alex_blood.SetActive(false);
            Alex_sleeping.SetActive(true);

            SarahCorpse.SetActive(true);
            UI.SetActive(false);
            heartbeat.volume = 0;
            beep.volume = 0;
            dead.Play();
            StartCoroutine(YouKilledHer());

        }
        else if(sharedData.dillemaPatient == 2 ) //saved Sarah -> Alex killed
        {
            Alex.SetActive(false);
            Sarah.SetActive(false);
            Sarah_blood.SetActive(false);

            Sarah_sleeping.SetActive(true);

            AlexCorpse.SetActive(true);
            

            UI.SetActive(false);
            heartbeat.volume = 0;
            beep.volume = 0;
            dead.Play();
            StartCoroutine(YouKilledHim());
        }
    }

    private IEnumerator YouKilledHim()
    {
        AlexDead.SetActive(true);
        yield return new WaitForSeconds(2.9f);
        glitch.Play();
        yield return new WaitForSeconds(0.1f);

        AlexDead.SetActive(false);
        AlexKilled.SetActive(true);
        
        yield return new WaitForSeconds(0.2f);
        AlexKilled.SetActive(false);
        AlexDead.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        glitch.volume = 0;

        yield return new WaitForSeconds(1f);

        glitch.volume = 1;
        AlexDead.SetActive(false);
        AlexKilled.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        AlexKilled.SetActive(false);
        AlexDead.SetActive(true);
        glitch.volume = 0;

        yield return new WaitForSeconds(1f);

        glitch.volume = 1;
        AlexDead.SetActive(false);
        AlexKilled.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        AlexKilled.SetActive(false);
        AlexDead.SetActive(true);
        glitch.volume = 0;

        yield return new WaitForSeconds(0.7f);

        glitch.volume = 1;
        AlexDead.SetActive(false);
        AlexKilled.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        AlexKilled.SetActive(false);
        AlexDead.SetActive(true);
        glitch.volume = 0;


        Flick.enabled = true;

        for (int i=0; i<30; i++)
        {
            yield return new WaitForSeconds(0.05f);
            glitch.volume = 1;
            AlexDead.SetActive(false);
            AlexKilled.SetActive(true);
            yield return new WaitForSeconds(0.05f);
            AlexKilled.SetActive(false);
            AlexDead.SetActive(true);
            glitch.volume = 0;
        }
        

        SceneManager.LoadScene("MapScene");
        
    }
    private IEnumerator YouKilledHer()
    {
        SarahDead.SetActive(true);
        yield return new WaitForSeconds(2.9f);
        glitch.Play();
        yield return new WaitForSeconds(0.1f);

        SarahDead.SetActive(false);
        SarahKilled.SetActive(true);

        yield return new WaitForSeconds(0.2f);
        SarahKilled.SetActive(false);
        SarahDead.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        glitch.volume = 0;

        yield return new WaitForSeconds(1f);

        glitch.volume = 1;
        SarahDead.SetActive(false);
        SarahKilled.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        SarahKilled.SetActive(false);
        SarahDead.SetActive(true);
        glitch.volume = 0;

        yield return new WaitForSeconds(1f);

        glitch.volume = 1;
        SarahDead.SetActive(false);
        SarahKilled.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        SarahKilled.SetActive(false);
        SarahDead.SetActive(true);
        glitch.volume = 0;

        yield return new WaitForSeconds(0.7f);

        glitch.volume = 1;
        SarahDead.SetActive(false);
        SarahKilled.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        SarahKilled.SetActive(false);
        SarahDead.SetActive(true);
        glitch.volume = 0;


        Flick.enabled=true;
        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForSeconds(0.05f);
            glitch.volume = 1;
            SarahDead.SetActive(false);
            SarahKilled.SetActive(true);
            yield return new WaitForSeconds(0.05f);
            SarahKilled.SetActive(false);
            SarahDead.SetActive(true);
            glitch.volume = 0;
        }


        SceneManager.LoadScene("MapScene");

    }
}

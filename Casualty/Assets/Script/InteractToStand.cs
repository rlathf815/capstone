using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class InteractToStand : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public GameObject ui;
    //public GameObject dillema;
    public SharedData sharedData;
    //public Transform player;
    public GameObject dialog1;
    public GameObject dialog2;
    public GameObject dialog3;
    public GameObject dialog4;
    public GameObject dialog5;
    public GameObject dialog6;
    public CanvasGroup canvasGroup;
    public GameObject blackout;

    // public KeyCode standUpKey = KeyCode.E;

    // Update is called once per frame
    void Update()
    {
        if (ui != null && ui.gameObject.activeSelf)
        {
            if (Input.GetKey(KeyCode.E))
            {
                animator.SetTrigger("Interaction");
                //   transform.LookAt(player);
                //   animator.SetFloat("LookWeight", 1f);
                ui.SetActive(false);
                StartCoroutine(showUI());
            }
        }
       // if (dillema != null && dillema.gameObject.activeSelf)
       // {
       //     if (Input.GetKey(KeyCode.Q))
       //     {
       //         //추후 수정.
       //         sharedData.dillemaPatient = 0;
       //         SceneManager.LoadScene("StitchMiniGameScene");
       //     }
       //     else if(Input.GetKey(KeyCode.E))
       //     {
       //         sharedData.dillemaPatient = 1;
       //
       //         SceneManager.LoadScene("StitchMiniGameScene");
       //
       //     }
       // }
    }
    private IEnumerator showUI()
    {
        yield return new WaitForSeconds(2f);
        //dillema.SetActive(true);
        dialog1.SetActive(true);
        yield return new WaitForSeconds(2f);
        dialog1.SetActive(false);

        dialog2.SetActive(true);
        yield return new WaitForSeconds(2f);
        dialog2.SetActive(false);

        dialog3.SetActive(true);
        yield return new WaitForSeconds(2f);
        dialog3.SetActive(false);

        dialog4.SetActive(true);
        yield return new WaitForSeconds(2f);
        dialog4.SetActive(false);

        dialog5.SetActive(true);
        yield return new WaitForSeconds(2f);
        dialog5.SetActive(false);

        dialog6.SetActive(true);
        yield return new WaitForSeconds(2f);
        dialog6.SetActive(false);

        yield return new WaitForSeconds(1.0f);

        blackout.SetActive(true);
        canvasGroup.alpha = 0f;
        yield return new WaitForSeconds(1f); 

       
        float fadeDuration = 0.5f; 
        while (canvasGroup.alpha < 1f)
        {
            canvasGroup.alpha += Time.deltaTime / fadeDuration;
            yield return null;
        }
        canvasGroup.alpha = 1f; 
        SceneManager.LoadScene("ChooseOne");
        
    }
}

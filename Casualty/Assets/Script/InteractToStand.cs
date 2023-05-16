using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class InteractToStand : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public GameObject ui;
    public GameObject dillema;
    public SharedData sharedData;
    //public Transform player;

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
        if (dillema != null && dillema.gameObject.activeSelf)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                //추후 수정.
                sharedData.dillemaPatient = 0;
                SceneManager.LoadScene("StitchMiniGameScene");
            }
            else if(Input.GetKey(KeyCode.E))
            {
                sharedData.dillemaPatient = 1;

                SceneManager.LoadScene("StitchMiniGameScene");

            }
        }
    }
    private IEnumerator showUI()
    {
        yield return new WaitForSeconds(2f);
        dillema.SetActive(true);
    }
}

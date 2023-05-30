using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToEndingCredit : MonoBehaviour
{
    public GameObject fadeIn;

    private void Start()
    {
        fadeIn.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Player")
        {

            StartCoroutine(wait());
        }
    }

    private IEnumerator wait()
    {
        fadeIn.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("ToEnding");
    }
}

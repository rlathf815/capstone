using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorEnter : MonoBehaviour
{
    private bool hasCoroutineStarted = false;
    public SharedData sharedData;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {



        if (other.gameObject.CompareTag("Player"))
        {

            Debug.Log("entered elevator");
            if (sharedData.bodyParked && !sharedData.bodyParked2)
            {
                StartCoroutine(SceneChange());
                hasCoroutineStarted = true;
            }
 

        }

    }
    private IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Dilemma");
    }

}

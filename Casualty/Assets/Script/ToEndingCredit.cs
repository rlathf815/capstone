using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToEndingCredit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Player")
        {
            SceneManager.LoadScene(9); // Ending Credit
        }
    }
}

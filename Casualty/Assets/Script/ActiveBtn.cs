using UnityEngine;
using UnityEngine.SceneManagement;

public class ActiveBtn : MonoBehaviour
{
    //public string nextSceneName;
    public GameObject UI;
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger entered" + other.tag);
        
        if (other.gameObject.CompareTag("PlayerController"))
        {
            UI.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                // Load the new scene
                SceneManager.LoadScene("MiniGameScene");
            }

        }

    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("trigger exited" + other.tag);
        if (other.gameObject.CompareTag("PlayerController"))
        {
            UI.SetActive(false);

        }
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActiveBtn : MonoBehaviour
{
    //public string nextSceneName;
    public GameObject UI;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger entered" + other.tag);
        // Check if the other collider is the player's controller
        //if (other.gameObject.CompareTag("PlayerController"))
        //{
        //    // Load the next scene
        //    SceneManager.LoadScene(nextSceneName);
        //}
        if (other.gameObject.CompareTag("PlayerController"))
        {
            UI.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

        }

    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("trigger exited" + other.tag);
        if (other.gameObject.CompareTag("PlayerController"))
        {
            UI.SetActive(false);
            Cursor.visible = false;

        }
    }
}
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    
    public string nextSceneName;
    public void SceneChange()
    {
        SceneManager.LoadScene(nextSceneName);
    }
    public void PrintLog()
    {
        Debug.Log("btn clicked");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HorrorMinigameClear : MonoBehaviour
{
    public GameObject jumpscare;
    public AudioClip jsSound;
    private AudioSource audioSource;
    public SharedData sharedData;
    // Start is called before the first frame update
    void Start()
    {
        sharedData.glitchOn = false;
        
        jumpscare.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        sharedData.horrorPatient = true;
        StartCoroutine(ClearScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ClearScene() //Coroutine 사용하여 씬 전환 전 잠시 딜레이
    {
        yield return new WaitForSeconds(13.0f);
        jumpscare.SetActive(true);
        audioSource.PlayOneShot(jsSound);
        sharedData.glitchOn = true;
        yield return new WaitForSeconds(1.0f);
        sharedData.glitchOn = false;

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("HorrorScene");
    }
}

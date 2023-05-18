using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public Canvas ui;
    public PatientData selectedPatient;
    public SharedData sharedData;
    private string name;
    public GameObject subtitle;
    public CanvasGroup canvasGroup;
    private float fadeInDuration = 0.7f;
    private float fadeOutDuration = 0.7f;
    private bool hasCoroutineStarted = false;
    public AudioClip audioClip;
    public GameObject smartphone;
    public Animator smartphoneAnimator;

    private AudioSource audioSource;

    void Start()
    {
        selectedPatient.description.Clear();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (ui != null && ui.gameObject.activeSelf)
        {
            if (Input.GetKey(KeyCode.E))
            {
                name = selectedPatient.patientName;

                System.Reflection.FieldInfo field = sharedData.GetType().GetField(name);
                if (field != null && field.FieldType == typeof(bool))
                {
                    bool currentValue = (bool)field.GetValue(sharedData);
                    if (!currentValue)
                    {
                        field.SetValue(sharedData, true);
                        Debug.Log("Processing patient: " + name);
                    }
                }
                else
                {
                    Debug.Log("Invalid patient name or field not found: " + name);
                }

                SceneManager.LoadScene("MiniGameScene");

            }
        }
        if (sharedData.patient1 && sharedData.patient2 && sharedData.patient3 && !hasCoroutineStarted)
        {
            Debug.Log("All clear");

            StartCoroutine(UIFade());
            hasCoroutineStarted = true;
        }

    }
    private IEnumerator UIFade()
    {
        // Fade in

        yield return new WaitForSeconds(0.5f);

        audioSource.clip = audioClip;
        audioSource.Play();
        yield return new WaitForSeconds(1f);
        smartphone.SetActive(true);
        
        yield return new WaitForSeconds(2f);
        smartphoneAnimator.SetBool("isDelayed", true);
        yield return new WaitForSeconds(2f);

        audioSource.Stop();
        smartphone.SetActive(false);

        subtitle.SetActive(true);

        canvasGroup.alpha = 0f;
        while (canvasGroup.alpha < 1f)
        {
            canvasGroup.alpha += Time.deltaTime / fadeInDuration;
            yield return null;
        }
        canvasGroup.alpha = 1f;

        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);

        // Fade out
        while (canvasGroup.alpha > 0f)
        {
            canvasGroup.alpha -= Time.deltaTime / fadeOutDuration;
            yield return null;
        }
        canvasGroup.alpha = 0f;

        subtitle.SetActive(false);
    }
}

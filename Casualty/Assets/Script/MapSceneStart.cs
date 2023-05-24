using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSceneStart : MonoBehaviour
{
    public SharedData sharedData;

    public GameObject subtitle;
    public CanvasGroup canvasGroup;
    public float fadeInDuration = 1f;  
    public float fadeOutDuration = 1f;
    // Start is called before the first frame update
    void Start()
    {
        if(sharedData.initial)
        {
            StartCoroutine(UIFade());
            sharedData.initial = false;
            sharedData.patient1 = false;
            sharedData.patient2 = false;
            sharedData.patient3 = false;
        }
        sharedData.glitchOn = false;

    }

    private IEnumerator UIFade()
    {
        // Fade in
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

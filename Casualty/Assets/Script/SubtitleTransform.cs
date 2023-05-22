using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class SubtitleTransform : MonoBehaviour
{
    public TMP_Text subtitleText;
    public SharedData sharedData;
    public CanvasGroup canvasGroup;

    public float delayBetweenTransformations = 0.5f;
    public GameObject subtitle;
    private string originalSubtitle = "Handle all patients";
    private string transformedSubtitle;
    private Coroutine transformationCoroutine;
    private Color[] colorSequence = { Color.red, new Color(0.482f, 0f, 0f), new Color(0.6603774f, 0f, 0f), new Color(0.5566038f, 0.1023941f, 0.1023941f), new Color(1f, 0.25f, 0.25f) };
    private bool hasCoroutineStarted = false;

    private void Start()
    {
        subtitle.SetActive(false);

    }
    void Update()
    {
        if (sharedData.HorrorInitial && sharedData.hasEntered && !hasCoroutineStarted)
        {
            transformedSubtitle = originalSubtitle;
            transformationCoroutine = StartCoroutine(TransformSubtitle());
            hasCoroutineStarted = true;
        }
    }

    private IEnumerator TransformSubtitle()
    {
        //yield return new WaitForSeconds(6f);

        subtitle.SetActive(true);
        canvasGroup.alpha = 0f;
        while (canvasGroup.alpha < 1f)
        {
            canvasGroup.alpha += Time.deltaTime / 0.7f;
            yield return null;
        }
        canvasGroup.alpha = 1f;
        yield return new WaitForSeconds(1f);

        int transformationIndex = 0;
        int colorIndex = 0;
        while (transformationIndex < originalSubtitle.Length)
        {
            transformedSubtitle = ApplyTransformation(originalSubtitle, transformationIndex);
            subtitleText.text = transformedSubtitle;
            subtitleText.color = colorSequence[colorIndex];
            transformationIndex++;
            colorIndex = (colorIndex + 1) % colorSequence.Length;
            yield return new WaitForSeconds(delayBetweenTransformations);
        }
        yield return new WaitForSeconds(2f);

        // Fade out
        while (canvasGroup.alpha > 0f)
        {
            canvasGroup.alpha -= Time.deltaTime / 0.7f;
            yield return null;
        }
        canvasGroup.alpha = 0f;

        subtitle.SetActive(false);
    }


    private string ApplyTransformation(string subtitle, int transformationIndex)
    {
        string transformedSubtitle = subtitle;
        for (int i = 0; i <= transformationIndex; i++)
        {
            char c = subtitle[i];
            if (c.ToString().ToLower() == "a")
                transformedSubtitle = transformedSubtitle.Substring(0, i) + "@" + transformedSubtitle.Substring(i + 1);
            else if (c.ToString().ToLower() == "e")
                transformedSubtitle = transformedSubtitle.Substring(0, i) + "3" + transformedSubtitle.Substring(i + 1);
            else if (c.ToString().ToLower() == "l")
                transformedSubtitle = transformedSubtitle.Substring(0, i) + "!" + transformedSubtitle.Substring(i + 1);
            else if (c.ToString().ToLower() == "p")
                transformedSubtitle = transformedSubtitle.Substring(0, i) + "*" + transformedSubtitle.Substring(i + 1);
            else if (c.ToString().ToLower() == "s")
                transformedSubtitle = transformedSubtitle.Substring(0, i) + "5" + transformedSubtitle.Substring(i + 1);
        }
        return transformedSubtitle;
    }

    private void OnDestroy()
    {
        if (transformationCoroutine != null)
            StopCoroutine(transformationCoroutine);
    }
}

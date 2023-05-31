using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JYtoEndCamera : MonoBehaviour
{

    private Animator animator;
    public AnimationClip toRun;
    public AnimationClip toTurn;
    public SharedData sharedData;

    public GameObject nurse;
    private Animator nurseAnim;

    public GameObject fadeOut;

    public GameObject sub;
    public CanvasGroup cv;

    // Start is called before the first frame update
    void Start()
    {
        nurse.SetActive(false);
        fadeOut.SetActive(false);

        animator = GetComponent<Animator>();
        nurseAnim = nurse.GetComponent<Animator>();

        StartCoroutine(PlayAct());

        sharedData.glitchOn = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator UIFade(GameObject gameobject, CanvasGroup canvasGroup)
    {
        gameobject.SetActive(true);

        canvasGroup.alpha = 0f;
        while (canvasGroup.alpha < 1f)
        {
            canvasGroup.alpha += Time.deltaTime / 0.7f;
            yield return null;
        }
        canvasGroup.alpha = 1f;

        yield return new WaitForSeconds(2f);

        while (canvasGroup.alpha > 0f)
        {
            canvasGroup.alpha -= Time.deltaTime / 0.7f;
            yield return null;
        }
        canvasGroup.alpha = 0f;

        gameobject.SetActive(false);
    }
    private IEnumerator PlayAct()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("wait");
        animator.SetTrigger("toRun");
        yield return new WaitForSeconds(toRun.length);
        animator.SetTrigger("toFall");      

        animator.SetTrigger("fallbreath");

        yield return new WaitForSeconds(2.5f);

        animator.SetTrigger("toTurn");
        nurse.SetActive(true);
        
        nurseAnim.SetTrigger("trig");
        yield return new WaitForSeconds(toTurn.length);
        StartCoroutine(UIFade(sub, cv));
        animator.SetTrigger("ToBreath");        
        yield return new WaitForSeconds(2.0f);
        fadeOut.SetActive(true);
        
        yield return new WaitForSeconds(3.0f);
        Debug.Log("scene");
        SceneManager.LoadScene("Ending");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StitchGameScript : MonoBehaviour
{
    public GameObject Cut_detect1;
    public GameObject Cut_detect2;//절개 시작과끝

    public Sprite StitchImage;
    private Vector3 originPos;
    private bool Cut_start = false;
    private bool isCut = false;
    public GameObject Guts;

    //private GameObject imageObj;

    public AudioClip cuttingSound;
    private AudioSource audioSource;

    public Image cutImage;
    // Start is called before the first frame update
    void Start()
    {
        Canvas myCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        cutImage = myCanvas.transform.Find("Cut_Through").GetComponent<Image>();
        //imageObj = GameObject.FindGameObjectWithTag("stitchImage");
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        originPos = other.gameObject.transform.position;
        if (other.gameObject == Cut_detect1 && Cut_start == false)
        {
            Cut_start = true;
            Debug.Log("C");
        }

        if(other.gameObject == Cut_detect2 && Cut_start == true)
        {
            isCut = true;
            Debug.Log("Cut");
            audioSource.PlayOneShot(cuttingSound);
            Cut_start = false;
            Guts.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isCut == true)
        {
            cutImage.gameObject.SetActive(false);
        }
    }

    void ImgChange()
    {
        Cut_detect1.SetActive(false);
        Cut_detect2.SetActive(false);
       
    }
}

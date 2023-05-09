using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private GameObject correctMove;
    private Vector3 originPos;
    public AudioClip correctActionSound;
    public AudioClip wrongActionSound;
    public GameObject UI;
    public GameObject[] objects;
    //public List<string> description;
    public PatientData selectedPatient;

    //private bool correct = false;;
    private int index = 0;
    private int max;

    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        objects = new GameObject[selectedPatient.description.Count];
        //description.AddRange(selectedPatient.description);
        Debug.Log(selectedPatient.description.Count );

        for (int i = 0; i < selectedPatient.description.Count; i++)
        {
            Debug.Log(selectedPatient.description[i] + " searching");
            GameObject obj = GameObject.Find(selectedPatient.description[i]);
            objects[i] = obj;
            Debug.Log("search result "+ objects[i]);
        }
        max = objects.Length;
        //correctMove = objects[index];

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(correctMove + "is the correct move");
        originPos = other.gameObject.transform.position;
        //Debug.Log("collision detected");
        if (other.gameObject == correctMove || other.gameObject.transform.IsChildOf(correctMove.transform))
        {
            Debug.Log("correct move - index"+ index + "out of "+ max + " "+other.gameObject);
            audioSource.PlayOneShot(correctActionSound);
            //correct = true;
            if (index < max - 1)
                index++;
            else
                UI.SetActive(true);
            
            
        }
        else
        {
            Debug.Log(other.gameObject);
            audioSource.PlayOneShot(wrongActionSound);

        }
    }
    void Update()
    {
       // Debug.Log("index" + index + "out of " + max);
        correctMove = objects[index];
      
    }
}

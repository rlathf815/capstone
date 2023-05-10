using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetector : MonoBehaviour
{
    private GameObject correctMove;
    private Vector3 originPos;
    public AudioClip correctActionSound;
    public AudioClip wrongActionSound;
<<<<<<< Updated upstream
=======
    public PatientData selectedPatient;
>>>>>>> Stashed changes
    [SerializeField] public GameObject[] objects;
    //private bool correct = false;;
    private int index = 0;
    private int max;
    public GameObject UI;
    private AudioSource audioSource;

    private void Start()
    {
        objects = new GameObject[selectedPatient.description.Count];
        Debug.Log(selectedPatient.description.Count);
        

        for (int i = 0; i < selectedPatient.description.Count; i++)
        {
            string objectName = selectedPatient.description[i];
            GameObject obj = GameObject.Find(objectName);
            objects[i] = obj;
            Debug.Log(obj + "added");
        }
        audioSource = GetComponent<AudioSource>();
        max = objects.Length;
        //correctMove = objects[index];

    }
    private void OnTriggerEnter(Collider other)
    {
        originPos = other.gameObject.transform.position;
        //Debug.Log("collision detected");
        if (other.gameObject == correctMove || other.gameObject.transform.IsChildOf(correctMove.transform))
        {
            Debug.Log("correct move");
            audioSource.PlayOneShot(correctActionSound);
            //correct = true;
            if (index < max - 1)
                index++;
<<<<<<< Updated upstream
            
=======
            else UI.SetActive(true);
>>>>>>> Stashed changes
        }
        else
        {
            Debug.Log(other.gameObject);
            audioSource.PlayOneShot(wrongActionSound);

        }
    }
    void Update()
    {
        correctMove = objects[index];
    }
}

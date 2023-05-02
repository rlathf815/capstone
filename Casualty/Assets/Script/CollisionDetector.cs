using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private GameObject correctMove;
    private Vector3 originPos;
    public AudioClip correctActionSound;
    public AudioClip wrongActionSound;
    [SerializeField] public GameObject[] objects;
    //private bool correct = false;;
    private int index = 0;
    private int max;

    private AudioSource audioSource;
    private void Start()
    {
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

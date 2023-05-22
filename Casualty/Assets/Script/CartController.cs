using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartController : MonoBehaviour
{
    public Transform player; 
    public Camera mainCamera; 
    public float heightOffset = 0.5f; 
    public GameObject cart;
    public GameObject newCart;
    public SharedData sharedData;
    private Vector3 offset; 

    private void Start()
    {
        if (sharedData.dillemaPatient != 0)
            cart.SetActive(true);
        else
            cart.SetActive(false);
        offset = transform.position - player.position;

       
        GetComponent<Collider>().enabled = false;
        newCart.SetActive(false);
        
    }

    private void FixedUpdate()
    {
        
        Vector3 targetPosition = player.position + mainCamera.transform.forward * offset.magnitude;
        targetPosition.y = player.position.y + heightOffset;

        
        transform.position = targetPosition;
    }

    private void LateUpdate()
    {
       
        GetComponent<Collider>().enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger entered" + other.tag);
       

        if (other.gameObject.CompareTag("ParkingSpot"))
        {
            Debug.Log("=========parked=========");

            cart.SetActive(false);
            newCart.SetActive(true);
            sharedData.bodyParked = true;
        }

    }
}
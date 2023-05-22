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
    public GameObject Alex;
    public CanvasGroup alex;
    public GameObject Sarah;
    public CanvasGroup sarah;


    private void Start()
    {
        if (sharedData.dillemaPatient != 0)
        {
            Debug.Log("patient killed");
            if(sharedData.dillemaPatient ==1)
            {
                Alex.SetActive(false);
                StartCoroutine(subtitle(Sarah, sarah));
            }
            else if(sharedData.dillemaPatient ==2)
            {
                Sarah.SetActive(false);
                StartCoroutine(subtitle(Alex, alex));
            }
            cart.SetActive(true);
        }
            
        else
        {
            Debug.Log("patient not yet killed");
            Sarah.SetActive(false);
            Alex.SetActive(false);
            cart.SetActive(false);
        }
            
        offset = transform.position - player.position;
        sharedData.bodyParked = false;


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
    private IEnumerator subtitle(GameObject subtitle, CanvasGroup canvasGroup)
    {
        subtitle.SetActive(true);
        while (canvasGroup.alpha < 1f)
        {
            canvasGroup.alpha += Time.deltaTime / 0.7f;
            yield return null;
        }
        canvasGroup.alpha = 1f;

        // Wait for 2 seconds
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
}
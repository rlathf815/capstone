using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshMovingBed2 : MonoBehaviour
{
    public Vector3 Distance = new Vector3(0f, 0f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + Distance, 0.1f);
    }
}

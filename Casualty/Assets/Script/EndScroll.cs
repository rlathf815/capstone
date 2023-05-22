using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScroll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //юс╫ц
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < 4.3)
        {
            transform.position += Vector3.up * 0.15f * Time.deltaTime;
        }
        
    }
}

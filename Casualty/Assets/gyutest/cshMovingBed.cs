using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshMovingBed : MonoBehaviour
{
    public int SpawnTime = 0;
    public GameObject Bed;
    public GameObject SpawnPoint;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            for (; SpawnTime > 0; SpawnTime -= 1)
            { 
                Instantiate(Bed, SpawnPoint.transform.position, Quaternion.identity);
            }
        }
    }
}

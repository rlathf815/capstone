using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshDilemaPlayerState : MonoBehaviour
{
    public GameObject Humanoid;
    public LookAtPlayer lookAtPlayer;
    // Start is called before the first frame update
    void Start()
    {
        lookAtPlayer = Humanoid.GetComponent<LookAtPlayer>();//from Q
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

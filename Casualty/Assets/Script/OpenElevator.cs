using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenElevator : MonoBehaviour
{
    public bool OnOff;//for test, public

    public GameObject LeftDoor;
    public GameObject RightDoor;
    Vector3 LPos;
    Vector3 RPos;
    Vector3 RMove = new Vector3(0.7f, 0, 0);
    Vector3 LMove = new Vector3(-0.7f, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        OnOff = false;
        
        LPos = LeftDoor.transform.position;
        RPos = RightDoor.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if(OnOff == false)
        {
            if (LeftDoor.transform.position == LPos+LMove && RightDoor.transform.position == RPos+RMove)
            {
                RightDoor.transform.Translate(LMove);
                LeftDoor.transform.Translate(RMove);
            }
               
        }
        if(OnOff == true)
        {
            if (LeftDoor.transform.position == LPos && RightDoor.transform.position == RPos)
            {
                RightDoor.transform.Translate(RMove);
                LeftDoor.transform.Translate(LMove);
            }

        }
    }
}

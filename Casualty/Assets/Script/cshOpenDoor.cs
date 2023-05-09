using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshOpenDoor : MonoBehaviour
{
    public bool OnOff;//for test, public
    public float speed = 1f;
    public GameObject LeftDoor;
    public GameObject RightDoor;
    public float openingSpeed = 0.01f;
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
        if (OnOff == false)
        {
            if (LeftDoor.transform.position != LPos && RightDoor.transform.position != RPos)
            {
                RightDoor.transform.position = Vector3.MoveTowards(RightDoor.transform.position, RPos, openingSpeed);
                //RightDoor.transform.Translate(LMove);
                LeftDoor.transform.position = Vector3.MoveTowards(LeftDoor.transform.position, LPos, openingSpeed);
                //LeftDoor.transform.Translate(RMove);
            }

        }
        if (OnOff == true)
        {
            if (LeftDoor.transform.position != LPos + LMove && RightDoor.transform.position != RPos + RMove)
            {
                RightDoor.transform.position = Vector3.MoveTowards(RightDoor.transform.position, RMove + RPos, openingSpeed);
                //RightDoor.transform.Translate(RMove);
                LeftDoor.transform.position = Vector3.MoveTowards(LeftDoor.transform.position, LMove + LPos, openingSpeed);
                //LeftDoor.transform.Translate(LMove);
            }

        }
    }
}

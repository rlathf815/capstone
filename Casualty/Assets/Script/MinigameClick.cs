using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameClick : MonoBehaviour
{
    public Vector3 screenPoint;
    public Vector3 offset;

    public Vector3 dd;

    public bool isDragging = false;
    public GameObject hitObject;

    public Vector3 DraggingPosition;
    public Vector3 clickedObject;//드래그 시작한 물체 좌표 저장


    //벽바닥 제외하고 오브젝트는 그대론데 콜라이더만 움직이는 현상발생.
    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                isDragging = true;
                hitObject = hit.transform.gameObject;
                clickedObject = hitObject.transform.position;
                Debug.Log(hitObject);
            }
        }

        if (Input.GetMouseButton(0))
        {         
        }

        

        if (Input.GetMouseButtonUp(0))
        {
            hitObject.transform.position = clickedObject;//드래그를 그만두면 제자리로 돌아감.
            isDragging = false;
            DraggingPosition = new Vector3();
            clickedObject = new Vector3();
        }

        if (isDragging)
        {
            dd = hitObject.transform.position;
            DraggingPosition = new Vector3(Input.mousePosition.x/-1280, 1.5f, Input.mousePosition.y/-720);
            hitObject.transform.position = DraggingPosition;
        }
    }
}
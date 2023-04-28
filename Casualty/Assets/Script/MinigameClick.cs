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
    public Vector3 clickedObject;//�巡�� ������ ��ü ��ǥ ����


    //���ٴ� �����ϰ� ������Ʈ�� �״�е� �ݶ��̴��� �����̴� ����߻�.
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
            hitObject.transform.position = clickedObject;//�巡�׸� �׸��θ� ���ڸ��� ���ư�.
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameClick : MonoBehaviour
{
    public bool isDragging = false;
    public GameObject hitObject;
    private RaycastHit hit;

    public Vector3 DraggingPosition;
    public Vector3 clickedObject;//�巡�� ������ ��ü ��ǥ ���� , ���콺�� ���� ���� �ڸ��� �������°Ϳ� ����.

    //���콺�� �÷����� ������Ʈ�� ��������, ������Ʈ ��ġ�� �̸� ui�� ��ġ���� �����.

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            
            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Med"))
            {
                isDragging = true;
                hitObject = hit.transform.gameObject;
                clickedObject = hitObject.transform.position;
                Debug.Log(hitObject);
            }
        }


        if (Input.GetMouseButtonUp(0))
        {
            hitObject.transform.position = clickedObject;//�巡�׸� �׸��θ� ���ڸ��� ���ư�.
            isDragging = false;
            DraggingPosition = new Vector3();
            clickedObject = new Vector3();
            hitObject = null;
        }

        if (isDragging)
        {
            //�巡�� �߿� ���̰� �������� �巡������������ ���� ����
            //�±׶� ������Ʈ ��ġ�ϸ� ��.
            //UI�����ؾ���.
            if (Physics.Raycast(ray, out hit))
            {
                DraggingPosition = hit.point;
                DraggingPosition.y = 1.2f;
            }          
            hitObject.transform.position = DraggingPosition;
            
        }
    }
    
}
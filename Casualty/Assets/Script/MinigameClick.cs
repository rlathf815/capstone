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
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
    }
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

            if (Physics.Raycast(hitObject.transform.position, Vector3.down, out hit, 0.5f) && hit.collider.CompareTag("Collider"))
            {
                hitObject.transform.position = clickedObject;
                isDragging = false;
                DraggingPosition = new Vector3();
                clickedObject = new Vector3();
                hitObject = null;
            }
            //�巡�� �߿� ���̰� �������� �巡������������ ���� ����
            //�±׶� ������Ʈ ��ġ�ϸ� ��.
            //UI�����ؾ���.
            else
            {
                if (Physics.Raycast(ray, out hit))
                {
                    DraggingPosition = hit.point;
                    DraggingPosition.y = 1.3f;
                }
                hitObject.transform.position = DraggingPosition;
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameClick : MonoBehaviour
{
    public bool isDragging = false;
    public GameObject hitObject;
    private RaycastHit hit;



    public Vector3 DraggingPosition;
    public Vector3 clickedObject;//드래그 시작한 물체 좌표 저장 , 마우스를 떼면 원래 자리로 돌려놓는것에 쓰임.
    //마우스를 올려놓은 오브젝트를 강조할지, 오브젝트 위치에 이름 ui를 배치할지 고민중.
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
            hitObject.transform.position = clickedObject;//드래그를 그만두면 제자리로 돌아감.
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
            //드래그 중에 레이가 닿은곳을 드래깅포지션으로 새로 설정
            //태그랑 오브젝트 배치하면 됨.
            //UI설정해야함.
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
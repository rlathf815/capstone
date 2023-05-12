using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    public Camera playerCamera;
    public LayerMask pickUpLayerMask;
    public float pickUpRange;
    public Transform pickUpPoint;

    private Rigidbody currentObject;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // pick up
        {
            Ray CameraRay = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(CameraRay, out RaycastHit raycasthit, pickUpRange, pickUpLayerMask))
            {
                currentObject = raycasthit.rigidbody;
                currentObject.useGravity = false;

                // �����Ҷ��� ������ �־� �аų� ��� �� ����
                currentObject.mass = 0f;
            }
        }
        if (Input.GetMouseButtonUp(0) && currentObject != null) // drop
        {
            currentObject.useGravity = true;

            // ���� ���̰� �ּ� ���������� ������ ȸ��,�̵� �����ʵ��� ��
            currentObject.mass = 30f;
            currentObject = null;
        }
    }
    private void FixedUpdate()
    {
        if (currentObject)
        {
            setRotation();
            move();
        }
    }
    void setRotation()
    {
        // ħ�븦 ī�޶� ����� ��ġ�ϰ� ȸ��, �� x,z���⸸ �����ϰ� �ؾ���. y������ �ǵ�� ħ�밡 ���� ȸ��
        Vector3 directionToCamera = playerCamera.transform.position - currentObject.position;
        directionToCamera.y = currentObject.position.y;
        Quaternion targetRotation = Quaternion.LookRotation(directionToCamera, Vector3.up);
        currentObject.MoveRotation(targetRotation);
    }
    void move()
    {
        // ������ ���� �ʰ� �ؾ���(axis y)
        Vector3 GroundedPos = new Vector3(pickUpPoint.position.x, currentObject.position.y, pickUpPoint.position.z);
        currentObject.MovePosition(pickUpPoint.position);
    }
}

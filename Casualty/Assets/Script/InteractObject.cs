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

                // 조작할때는 가볍게 둬야 밀거나 당길 수 있음
                currentObject.mass = 0f;
            }
        }
        if (Input.GetMouseButtonUp(0) && currentObject != null) // drop
        {
            currentObject.useGravity = true;

            // 질량 무겁게 둬서 해제했을때 빠르게 회전,이동 하지않도록 함
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
        // 침대를 카메라 방향과 일치하게 회전, 단 x,z방향만 나란하게 해야함. y방향을 건들면 침대가 위로 회전
        Vector3 directionToCamera = playerCamera.transform.position - currentObject.position;
        directionToCamera.y = currentObject.position.y;
        Quaternion targetRotation = Quaternion.LookRotation(directionToCamera, Vector3.up);
        currentObject.MoveRotation(targetRotation);
    }
    void move()
    {
        // 땅에서 뜨지 않게 해야함(axis y)
        Vector3 GroundedPos = new Vector3(pickUpPoint.position.x, currentObject.position.y, pickUpPoint.position.z);
        currentObject.MovePosition(pickUpPoint.position);
    }
}

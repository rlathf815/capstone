using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DilemmaMapScript : MonoBehaviour
{
    public GameObject Elevator;

    //public Transform ElevatorPos;
    public GameObject Player;
    public Transform player;

    public float speed = 1f;

    private bool isMoving = true;

    private Rigidbody rb;

    private float distanceToPlayer = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = Player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = rb.velocity.magnitude;
        float distance = Mathf.Abs(transform.position.x - player.position.x);

        /*
        if (Player.transform.position.x == -15)
        {
            
        }
        */
        
        if(transform.position.x >= -120)
        {
            if (distance < distanceToPlayer && isMoving)
            {
                // 일정 거리 이하로 가까워졌을 때, 멈추도록 합니다.
                isMoving = false;
            }
            else if (distance > distanceToPlayer && !isMoving)
            {
                // 일정 거리 이상으로 멀어졌을 때, 다시 이동합니다.
                isMoving = true;
            }
        }else if(transform.position.x < -120)
        {
            isMoving = false;
        }
       

        if (isMoving)
        {
            // 플레이어 쪽으로 이동합니다.
            float direction = Mathf.Sign(player.position.x - transform.position.x);
            transform.Translate(Vector3.right * direction * speed * Time.deltaTime);
        }
    }
}

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
                // ���� �Ÿ� ���Ϸ� ��������� ��, ���ߵ��� �մϴ�.
                isMoving = false;
            }
            else if (distance > distanceToPlayer && !isMoving)
            {
                // ���� �Ÿ� �̻����� �־����� ��, �ٽ� �̵��մϴ�.
                isMoving = true;
            }
        }else if(transform.position.x < -120)
        {
            isMoving = false;
        }
       

        if (isMoving)
        {
            // �÷��̾� ������ �̵��մϴ�.
            float direction = Mathf.Sign(player.position.x - transform.position.x);
            transform.Translate(Vector3.right * direction * speed * Time.deltaTime);
        }
    }
}

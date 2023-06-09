using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DilemmaMapScript : MonoBehaviour
{
    public GameObject Elevator;
    public SharedData sharedData;//쉐어드 데이터.
    public LookAtPlayer lookAtPlayer;
    public GameObject Humanoid;

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
        lookAtPlayer = Humanoid.GetComponent<LookAtPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lookAtPlayer.triggerGhost == true)
        {
            speed = rb.velocity.magnitude;
            float distance = Mathf.Abs(transform.position.x - player.position.x);

            /*
            if (Player.transform.position.x == -15)
            {

            }
            */

            if (transform.position.x >= -90)
            {//30거리 줄어들었음.
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
            }
            else if (transform.position.x < -90)
            {
                isMoving = false;
            }


            if (Player.transform.position.x < -104.5 && sharedData.dillemaRunOver == false)
            {//엘리베이터 안에 들어갔을 때

                sharedData.dillemaRunOver = true;

            }

            if (sharedData.dillemaRunOver)
            {
                StartCoroutine(YouEscaped());
            }

            if (isMoving)
            {
                // 플레이어 쪽으로 이동합니다.
                float direction = Mathf.Sign(player.position.x - transform.position.x);
                transform.Translate(Vector3.right * direction * speed * Time.deltaTime);
            }
        }
    }
    private IEnumerator YouEscaped()
    {
        yield return new WaitForSeconds(3.0f);

        SceneManager.LoadScene("HorrorScene");
    }
}
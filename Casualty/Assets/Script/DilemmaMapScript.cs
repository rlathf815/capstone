using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DilemmaMapScript : MonoBehaviour
{
    public GameObject Elevator;
    public SharedData sharedData;//����� ������.
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

            if (transform.position.x >= -120)
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
            }
            else if (transform.position.x < -120)
            {
                isMoving = false;
            }


            if (Player.transform.position.x < -134.5 && sharedData.dillemaRunOver == false)
            {//���������� �ȿ� ���� ��

                sharedData.dillemaRunOver = true;

            }

            if (sharedData.dillemaRunOver)
            {
                StartCoroutine(YouEscaped());
            }

            if (isMoving)
            {
                // �÷��̾� ������ �̵��մϴ�.
                float direction = Mathf.Sign(player.position.x - transform.position.x);
                transform.Translate(Vector3.right * direction * speed * Time.deltaTime);
            }
        }
    }
    private IEnumerator YouEscaped()
    {
        yield return new WaitForSeconds(4.0f);

        SceneManager.LoadScene("HorrorScene");
    }
}
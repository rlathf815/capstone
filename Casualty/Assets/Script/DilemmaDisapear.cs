using System.Collections;
using UnityEngine;

public class DilemmaDisapear : MonoBehaviour
{
    public GameObject Player;
    public AudioClip whisper;
    private AudioSource audioSource;

    private bool isDestroying = false; // �ı� ������ ���θ� ��Ÿ���� �÷���
    public float destroyDelay = 1f; // ���� �ı� �ð�

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Player.transform.position.x < transform.position.x && !isDestroying)
        {
            audioSource.PlayOneShot(whisper);
            StartCoroutine(DestroyDelayed());
        }
    }

    private IEnumerator DestroyDelayed()
    {
        isDestroying = true; // �ı� �� �÷��� ����

        yield return new WaitForSeconds(destroyDelay); // ���� �ð���ŭ ���

        Destroy(gameObject); // ���� ������Ʈ �ı�
    }
}
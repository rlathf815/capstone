using System.Collections;
using UnityEngine;

public class DilemmaDisapear : MonoBehaviour
{
    public GameObject Player;
    public AudioClip whisper;
    private AudioSource audioSource;

    private bool isDestroying = false; // 파괴 중인지 여부를 나타내는 플래그
    public float destroyDelay = 1f; // 지연 파괴 시간

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
        isDestroying = true; // 파괴 중 플래그 설정

        yield return new WaitForSeconds(destroyDelay); // 지연 시간만큼 대기

        Destroy(gameObject); // 게임 오브젝트 파괴
    }
}
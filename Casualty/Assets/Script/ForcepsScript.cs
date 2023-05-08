using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForcepsScript : MonoBehaviour
{

    public Vector3 ForcepsPos;
    public GameObject Guts;
    public GameObject Bullet;
    public GameObject Bullet2;
    private GameObject chBullet;
    public Vector3 bulletPos;

    public Image stitched;

    public AudioClip dropBullet;
    private AudioSource audioSource;

    private bool isgrab = false;
    // Start is called before the first frame update
    void Start()
    {
        bulletPos = Bullet.transform.position;
        chBullet = this.gameObject.GetComponent<Transform>().GetChild(2).gameObject;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ForcepsPos = this.gameObject.transform.position;

        if (Guts.activeSelf && Bullet2.activeSelf == false && isgrab == false)
        {
            Bullet.SetActive(true);
        }

        if (Bullet.activeSelf && (ForcepsPos.x >= -1.03f && ForcepsPos.x <= -1.0f) && (ForcepsPos.z >= -0.13f && ForcepsPos.z <= -0.08))
        {//총알 잡기
            Bullet.gameObject.SetActive(false);
            isgrab = true;
        }


        if (isgrab)
        {
            chBullet.gameObject.SetActive(true);

            if((ForcepsPos.x >= -0.92f && ForcepsPos.x <= -0.85f) && (ForcepsPos.z >= -0.18f && ForcepsPos.z <= -0.08)){
                chBullet.gameObject.SetActive(false);
                isgrab = false;
                Bullet2.gameObject.SetActive(true);
                audioSource.PlayOneShot(dropBullet);

                
            }//양동이에 총알넣기
        }

        if (Bullet2.activeSelf)
        {
            stitched.gameObject.SetActive(true);
        }

    }

    
}

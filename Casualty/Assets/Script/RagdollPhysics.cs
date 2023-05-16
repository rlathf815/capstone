using UnityEngine;
using System.Collections;
public class RagdollPhysics : MonoBehaviour
{
    [SerializeField]
    //Rigidbody spineRigidBody;
    Rigidbody leftKnee;

    [SerializeField]
    Rigidbody rightKnee;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(push());


    }
    IEnumerator push()
    {
        yield return new WaitForSeconds(0.2f);
        //spineRigidBody.AddForce(new Vector3(0f, 1000f, 1000f));
        leftKnee.AddForce(new Vector3(0f, 1000f, 1000f));
        rightKnee.AddForce(new Vector3(0f, 1000f, 1000f));

    }
}
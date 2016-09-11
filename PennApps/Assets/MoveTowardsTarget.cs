using UnityEngine;
using System.Collections;

public class MoveTowardsTarget : MonoBehaviour {

    float speed;
    Transform targetTransform;
    public Transform cameraPosition;
    //public Vector3 origin = new Vector3(0.0f, 0.0f, 0.0f);
    public bool doMove = false;

    void Start () {
        speed = 0.005f;
        targetTransform = transform.parent.Find("Target").transform;
	}
	
	void Update () {
        if (doMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, speed);
        }
        MovePhoto();
	}
    void MovePhoto()
    {
        Vector3 normal = Vector3.Normalize(transform.position - cameraPosition.position);
        transform.rotation = Quaternion.LookRotation(normal);
    }

}

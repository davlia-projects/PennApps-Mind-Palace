using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    float scale;
    float minDistance, maxDistance;
    float thrust;
    float centripetal;
    float angular;
    Rigidbody rb;
    public Vector3 origin;
    Vector3 rotation;
    bool inOrbit;
    GameObject picture;

    // Use this for initialization
    void Start () {
        scale = 0.005f;
        minDistance = 1.0f;
        maxDistance = 3.0f;
        thrust = 3.0f;
        centripetal = 0.5f;
        angular = 0.5f;
        rb = GetComponent<Rigidbody>();
        rotation = Random.onUnitSphere;
        inOrbit = false;

    }
	
	public void Move()
    {
        MovePhoto();
        Vector3 force = Vector3.zero;
        Vector3 normal = Vector3.Normalize(transform.position - origin);
        float dist = Vector3.Distance(origin, transform.position);
        if (!inOrbit)
        {
            rb.velocity = normal;
            if (dist > minDistance)
            {
                inOrbit = true;
            }
            return;
        }
        if (dist < minDistance)
        {
            force += normal * thrust;
        }
        else if (dist > maxDistance)
        {
            force += normal * -thrust;
        }
        else
        {
            force += normal * -centripetal;
        }

        force += (Vector3.Normalize(Vector3.ProjectOnPlane(rotation, normal)) * angular);
        rb.AddForce(force, ForceMode.Acceleration);

    }

    void MovePhoto()
    {
        Vector3 normal = Vector3.Normalize(transform.position - origin);
        transform.rotation = Quaternion.LookRotation(normal);
    }
}

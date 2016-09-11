using UnityEngine;
using System.Collections;

public class GrabMemorySphere : MonoBehaviour {
    bool isGrabbing;
    Transform targetedSphere = null;
    Transform grabbedSphere = null;
    public SteamVR_TrackedObject trackedObject;
    public Transform imageGrabberPlane;
	void Start () {
        isGrabbing = false;
	}

    void Update()
    {
        var device = SteamVR_Controller.Input((int)trackedObject.index);
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            if (targetedSphere != null)
            {
                grabbedSphere = targetedSphere;
                grabbedSphere.GetComponent<MoveTowardsTarget>().doMove = false;
                isGrabbing = true;
                imageGrabberPlane.GetComponent<Renderer>().enabled = true;
                imageGrabberPlane.GetComponent<Renderer>().material.mainTexture = 
                    grabbedSphere.Find("Plane").GetComponent<Renderer>().material.mainTexture;
                grabbedSphere.GetComponent<Renderer>().enabled = false;
                grabbedSphere.Find("Plane").GetComponent<Renderer>().enabled = false;
            }
        }
        else if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            if (isGrabbing)
            {
                grabbedSphere.GetComponent<MoveTowardsTarget>().doMove = true;
                isGrabbing = false;
                grabbedSphere.position = transform.position;
                grabbedSphere.GetComponent<Renderer>().enabled = true;
                grabbedSphere.Find("Plane").GetComponent<Renderer>().enabled = true;
                imageGrabberPlane.GetComponent<Renderer>().enabled = false;
                grabbedSphere = null;
            }
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (isGrabbing == false)
        {
            targetedSphere = collider.transform;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (isGrabbing == false)
        {
            if (targetedSphere == collider.transform)
            {
                targetedSphere = null;
            }
        }
    }
}

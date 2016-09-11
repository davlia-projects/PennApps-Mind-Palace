using UnityEngine;
using System.Collections;

public class MemorySphereController : MonoBehaviour {

    public GameObject controllerModel;
    Transform controllerTip = null;

    bool isLocked = false;

	void Start () {
    }

    void Awake()
    {
        
    }

    public void LockToController()
    {
        isLocked = true;
        transform.Find("Sphere").GetComponent<MoveTowardsTarget>().doMove = false;
    }

    public void ReleaseFromController()
    {
        isLocked = false;
        transform.Find("Sphere").GetComponent<MoveTowardsTarget>().doMove = true;
    }

    public void SetPictureTexture(Texture texture)
    {
        transform.Find("Sphere").Find("Plane").GetComponent<Renderer>().material.mainTexture = texture;
    }
	
	void Update () {
	    if (isLocked)
        {
            if (controllerTip == null)
            {
                controllerTip = controllerModel.transform.Find("tip").Find("attach").GetComponent<Transform>();
            }
            transform.Find("Sphere").transform.position = controllerTip.transform.position;
        }
	}
}

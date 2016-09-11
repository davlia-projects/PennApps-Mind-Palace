using UnityEngine;
using System.Collections;

public class AttachToController : MonoBehaviour {

    public GameObject vrControllerModel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        try
        {
            Transform tip = vrControllerModel.transform.Find("tip");
            if (tip != null)
            {
                Transform attachObject = tip.Find("attach");
                transform.position = attachObject.position;
                transform.rotation = attachObject.rotation;
            }
        } catch (System.NullReferenceException exception)
        {
            Debug.Log("Null reference!" + exception);
        }
	}
}

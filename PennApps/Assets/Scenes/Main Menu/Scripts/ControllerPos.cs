using UnityEngine;
using System.Collections;

public class ControllerPos : MonoBehaviour {

    private Valve.VR.EVRButtonId trigger = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device controller {get{return SteamVR_Controller.Input((int)trackedObj.index); }}
   

    bool buttonPress = false;

	// Use this for initialization
	void Start () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
	
	}
	
	// Update is called once per frame
	void Update () {
        if (controller == null)
        {
            Debug.Log("controller not initialized");
			return;
        }
        buttonPress = controller.GetPress(trigger);
	    if (buttonPress)
        {
            Debug.Log("ButtonPressed");
        }
	}
}

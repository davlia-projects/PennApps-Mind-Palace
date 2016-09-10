using UnityEngine;
using System.Collections;

public class ClickMenu : MonoBehaviour {
    SteamVR_TrackedObject trackedObject;
    public MenuController menuController;
    public Draw canvas;
    Vector3 lastPos;
    int finishDraw = 0;
   

	void Awake()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        canvas = new Draw();
    }
	
	void Update () {
       
        var device = SteamVR_Controller.Input((int)trackedObject.index);
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            finishDraw++;
            Debug.Log("Triggered");
            getPositions();
            menuController.goToSelectedLevel();

        }
        else if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            finishDraw = 0;

        }
        
        for (int i = 0; i < 5; i++) {
            onPositionChange();
        }

    }

    void getPositions()
    {
   
    //    Vector3 controllerLPos =  GameObject.FindGameObjectWithTag("LeftControllerSphere").transform.position;
        Vector3 controllerRPos = GameObject.FindGameObjectWithTag("RightControllerSphere").transform.position;
        Vector3 end = new Vector3(controllerRPos.x, controllerRPos.y, controllerRPos.z - 0.01f);
        Vector3 toDraw;

        if (finishDraw > 0) toDraw = lastPos;
        else toDraw = controllerRPos;

        canvas.drawLine(controllerRPos, end, Color.red);
        lastPos = controllerRPos;
        
    }

    void onPositionChange()
    {
        Vector3 controllerRPos = GameObject.FindGameObjectWithTag("RightControllerSphere").transform.position;
        if (controllerRPos != lastPos && finishDraw > 0)
        {
            getPositions();
        }
    }
}

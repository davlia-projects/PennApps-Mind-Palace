using UnityEngine;
using System.Collections;

public class PointImageSelectorToHead : MonoBehaviour {

    public GameObject cameraEye;
    public GameObject controller;
    public float DISTANCE = 0.0f;

    public void Update()
    {
        if (cameraEye != null && controller != null)
        {
            Transform cameraLocation = cameraEye.GetComponent<Transform>();
            Transform tip = controller.transform.Find("tip");
            if (tip != null)
            {
                Transform controllerLocation = tip.Find("attach");
                if (controllerLocation != null)
                {
                    transform.position = controllerLocation.position;
                    transform.rotation = controllerLocation.rotation;
                }
            }
        }
    }
}

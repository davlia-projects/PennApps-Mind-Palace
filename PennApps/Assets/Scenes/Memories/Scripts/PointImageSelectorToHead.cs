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
            Transform controllerLocation = controller.transform.Find("tip").transform.Find("attach").GetComponent<Transform>();
            transform.position = controllerLocation.position;
            transform.rotation = controllerLocation.rotation;
        }
    }
}

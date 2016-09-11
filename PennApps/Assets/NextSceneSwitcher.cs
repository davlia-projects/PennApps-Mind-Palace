using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextSceneSwitcher : MonoBehaviour {
    public string nextSceneName;
    SteamVR_TrackedObject trackedObject;
    double timerStart;
    double THRESHOLD = 2.0f;
    void Awake()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        timerStart = -1.0f;
    }

    void FixedUpdate()
    {
        var device = SteamVR_Controller.Input((int)trackedObject.index);
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            print("test");
            if (timerStart < -1.0f)
            {
                timerStart = Time.time;
            }
            if (Time.time - timerStart > THRESHOLD)
            {
                SceneManager.LoadScene(nextSceneName);
            }
        } else if (device.GetTouchUp(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            timerStart = -1.0f;
        }
    }
}

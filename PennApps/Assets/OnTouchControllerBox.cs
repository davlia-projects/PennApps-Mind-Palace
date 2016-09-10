using UnityEngine;
using System.Collections;

public class OnTouchControllerBox : MonoBehaviour {
    int enterTimer = 3;
    public MenuController menuController;
    public string sceneName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Renderer renderer = GetComponent<Renderer>();
        enterTimer++;
        if (enterTimer > 3)
        {
            renderer.material.color = Color.red;
            if (menuController.nextSceneName == sceneName)
            {
                menuController.nextSceneName = null;
            }
        } else
        {
            renderer.material.color = Color.green;
            menuController.nextSceneName = sceneName;
        }
	}

    void onTriggerHit(Collider collider)
    {
        if (collider.gameObject.name == "LeftControllerSphere" || collider.gameObject.name == "RightControllerSphere")
        {
            enterTimer = 0;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        onTriggerHit(collider);
    }

    void OnTriggerStay(Collider collider)
    {
        onTriggerHit(collider);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour {
    public string nextSceneName = null;

	// Use this for initialization
	void Start () {
        nextSceneName = null;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void goToSelectedLevel()
    {
        if (nextSceneName != null)
        {
            //SceneManager.LoadScene(nextSceneName);
            print(nextSceneName);
        }
    }
}

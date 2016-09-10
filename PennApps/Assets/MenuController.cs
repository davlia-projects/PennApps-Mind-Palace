using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour {
    Color UNSELECTED = Color.red;
    Color SELECTED = Color.green;
    public string nextSceneName = null;
    public MenuButton nextSceneMenuButton;

	// Use this for initialization
	void Start () {
        nextSceneName = null;
        nextSceneMenuButton = null;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void goToSelectedLevel()
    {
        if (nextSceneMenuButton != null)
        {
            SceneManager.LoadScene(nextSceneMenuButton.sceneName);
            print(nextSceneMenuButton.sceneName);
        }
    }

    public void OnEnterButton(MenuButton button)
    {
        if (nextSceneMenuButton != null)
        {
            return;
        }
        Renderer renderer = button.GetComponentInParent<Renderer>();
        renderer.material.color = SELECTED;
        nextSceneMenuButton = button;
    }

    public void OnExitButton(MenuButton button)
    {
        Renderer renderer = button.GetComponentInParent<Renderer>();
        renderer.material.color = UNSELECTED;
        nextSceneMenuButton = null;
        return;
    }
}

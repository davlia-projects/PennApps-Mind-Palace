using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SphereSpawner : MonoBehaviour {
	public GameObject memoryModel;
    public List<GameObject> memories;
    float radius;

    // Use this for initialization
    void Start () {
		InvokeRepeating ("NewSphere", 1, 2);
		this.radius = 2.0f;
	}

	void NewSphere() {

        Vector3 randomLoc = Random.onUnitSphere;
        randomLoc.y = Mathf.Abs(randomLoc.y);
        Vector3 offset = randomLoc * radius;
		GameObject memory = Instantiate (memoryModel, this.transform.position + offset, Quaternion.identity) as GameObject;
        memories.Add(memory);
	}

    public void Test() {
        Debug.Log("Worked");
    }
}

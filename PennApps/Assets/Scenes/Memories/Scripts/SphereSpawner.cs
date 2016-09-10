using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SphereSpawner : MonoBehaviour {
	public GameObject memoryModel;
    public List<GameObject> memories;
    float scale;

    // Use this for initialization
    void Start () {
		InvokeRepeating ("NewSphere", 1, 2);
		this.scale = 1.0f;
	}

	void NewSphere() {
		Vector3 offset = Random.onUnitSphere * scale;
		GameObject memory = Instantiate (memoryModel, this.transform.position + offset, Quaternion.identity) as GameObject;
        memories.Add(memory);
	}

    public void Test() {
        Debug.Log("Worked");
    }
}

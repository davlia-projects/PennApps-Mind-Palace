using UnityEngine;
using System.Collections;

public class SphereSpawner : MonoBehaviour {
	public GameObject memoryModel;
	private float scale;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("NewSphere", 1, 2);
		this.scale = 3.0f;
	}

	void NewSphere() {
		Vector3 offset = Random.onUnitSphere * scale;
		Instantiate (memoryModel, this.transform.position + offset, Quaternion.identity);
	}
}

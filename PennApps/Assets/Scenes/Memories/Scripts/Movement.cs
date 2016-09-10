using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    float scale;
	// Use this for initialization
	void Start () {
        scale = 0.01f;
	}
	
	public void Move()
    {
        transform.Translate(transform.forward * Mathf.Sin(Time.time) * scale);
        transform.Translate(transform.right * Mathf.Cos(Time.time) * scale);

    }
}

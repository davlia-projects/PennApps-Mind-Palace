using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    float scale;
    float offsetX;
    float offsetY;
	// Use this for initialization
	void Start () {
        scale = 0.001f;
        offsetX = Random.value;
        offsetY = Random.value;
        
	}
	
	public void Move()
    {
        transform.Translate(transform.forward * Mathf.Sin(Time.time + offsetX * 2 * Mathf.PI) * scale);
        transform.Translate(transform.right * Mathf.Cos(Time.time + offsetY * 2 * Mathf.PI) * scale);

    }
}

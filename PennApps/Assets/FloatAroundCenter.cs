using UnityEngine;
using System.Collections;

public class FloatAroundCenter : MonoBehaviour {

    float angle;
    float radius;
    float DELTA = 0.005f;
    float centerHeight;
    float amplitude;
    float frequency;

	void Start () {
        radius = 1.5f;
        centerHeight = 1.5f;
        amplitude = 0.4f;
        frequency = 0.7f;
        angle = Random.Range(0, 2 * Mathf.PI);
	}
	
	void Update () {
        angle += DELTA;
        transform.position = new Vector3(
            radius * Mathf.Cos(angle),
            centerHeight + amplitude * Mathf.Sin(angle / frequency),
            radius * Mathf.Sin(angle)
        );
	}

    
}

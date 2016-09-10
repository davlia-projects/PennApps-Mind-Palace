#pragma strict

var offset : float;
var coeff : float;
function Start () {
	offset = (2 * Mathf.PI) * Random.value;
	coeff = (2 * Random.value);
}

function Update () {
	var dy = Mathf.Sin(Time.realtimeSinceStartup + offset);
	var dx = Mathf.Sin(coeff * Time.realtimeSinceStartup + offset);
	var dz = Mathf.Cos(coeff * Time.realtimeSinceStartup + offset);
	transform.Translate(0, dy * 0.05, 0);
	transform.Translate(dx * 0.05, 0, 0);
	transform.Translate(0, 0, dz * 0.05);
}
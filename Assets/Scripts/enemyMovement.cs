using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {
	public float velocityMax, yMax ,yMin;
	private float y, time, angle;
	void Start(){
		y = Random.Range (-velocityMax, velocityMax);
	}
	void Update(){
		time += Time.deltaTime;
		if (transform.localPosition.y > yMax) {
			y = Random.Range (-velocityMax, 0.0f);
			time = 0.0f;
		}
		if (transform.localPosition.y < yMin) {
			y = Random.Range (0.0f, velocityMax);
			time = 0.0f;
		}
		if (time > 1.0f) {
			y = Random.Range (-velocityMax, velocityMax);
			time = 0.0f;
		}
		transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y + y, transform.localPosition.z);
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Mover : MonoBehaviour {

	//Speed
	public float speed;

	void Start ()
	{
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
}

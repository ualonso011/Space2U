using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotator : MonoBehaviour 
{
	public Vector3 tumble;

	void Update ()
	{
		GetComponent<Rigidbody>().angularVelocity = tumble;
	}
}

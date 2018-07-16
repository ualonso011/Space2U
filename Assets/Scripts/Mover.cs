using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	//Speed
	public float speed;
	void Start ()
	{
		GetComponent<Rigidbody>().velocity = -transform.forward * speed;
	}
}

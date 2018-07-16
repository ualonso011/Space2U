using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_By_Boundary : MonoBehaviour {
	private GameController gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	//This will destroy all elements that pass the boundries. But only when the object is a triggered collider.
		void OnTriggerExit (Collider other)
	{
		if (other.tag == "Sol") {
			other.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
		} else {
			Destroy (other.gameObject);
			if (other.tag == "Player") GameObject.FindGameObjectWithTag ("GameController").GetComponent <GameController> ().GameOver ();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyWeaponCollision : MonoBehaviour 
{
	public GameObject explosion, playerExplosion;
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
	void OnTriggerEnter (Collider other)
	{
		//When the Enemy Ship hits the player
		if (other.CompareTag("Player")){
			if (playerExplosion != null)
				Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
			Destroy (gameObject);
			gameController.GameOver ();
		}
		if (other.CompareTag( "Weapon")) {
			if (explosion != null)
				Instantiate (explosion, transform.position, transform.rotation);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
		if (other.CompareTag("Boundary") || other.CompareTag("Untagged"))
		{
			return;
		}
	}
}

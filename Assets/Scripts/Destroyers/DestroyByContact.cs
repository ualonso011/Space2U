using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
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
		if (other.tag == "Player") {
			if (explosion != null) Instantiate(explosion, transform.position, transform.rotation);
			if (playerExplosion != null) Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
			Destroy (gameObject);
			gameController.GameOver ();
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			//gameController.GameOver();
		}
		if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}
		//gameController.AddScore(scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
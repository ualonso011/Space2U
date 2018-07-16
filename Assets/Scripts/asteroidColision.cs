using UnityEngine;
using System.Collections;

public class asteroidColision : MonoBehaviour
{
	public GameObject explosion, SandExplosion, playerExplosion, enemyExplosion, nextAsteroid;
	public int size;
	private bool neverDone;
	private GameController gameController;
	void Start ()
	{
		neverDone = true;
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
		//When the asteroid hits the player
		if (other.tag == "Player") {
			if (playerExplosion != null) Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
			Destroy (gameObject);
			gameController.GameOver ();
		}
		//When the asteroid is hitten by the shot
		//Will change size L->M->S->Destroy
		if (other.tag == "Weapon") {
			Destroy (other.gameObject);
			if (size == 1) {
				if (explosion != null)
					Instantiate (explosion, transform.position, transform.rotation);
				Destroy (gameObject);
				if (neverDone) {
					gameController.score = gameController.score + 5;
					gameController.scoreText.text = "SCORE = " + gameController.score;
					neverDone = false;
				}
			} else {
				if (SandExplosion != null)
					Instantiate (SandExplosion, transform.position, transform.rotation);
				Destroy (gameObject);
				if (neverDone) {
					gameController.score = gameController.score + 5;
					gameController.scoreText.text = "SCORE = " + gameController.score;
					Instantiate (nextAsteroid, transform.position, transform.rotation);
					neverDone = false;
				}
			}
		}
		if (other.tag == "EnemyWeapon") {
			Destroy (other.gameObject);
			if (size == 1) {
				if (explosion != null)
					Instantiate (explosion, transform.position, transform.rotation);
				Destroy (gameObject);
			} else {
				if (SandExplosion != null)
					Instantiate (SandExplosion, transform.position, transform.rotation);
				Destroy (gameObject);
				if (neverDone) {
					Instantiate (nextAsteroid, transform.position, transform.rotation);
					neverDone = false;
				}

			}
		}
		if (other.tag == "Enemy") {
			other.gameObject.GetComponent<enemySpaceShip>().hitByAsteroid ();
			Destroy (gameObject);
		}
		if (other.tag == "Boundary" || other.tag=="Untagged")
		{
			return;
		}
	}
}